using AutoMapper;
using DAL;
using Domain.Commands;
using Domain.Exceptions;

namespace Domain;

internal class CartFacade : ICartFacade
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;

    public CartFacade(ICartRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Cart Get(string id)
    {
        var cartDb = _repository.Get(id);
        if (cartDb is null)
        {
            throw new EntityNotFoundException($"Cart {id} does not exist");
        }
        return _mapper.Map<Cart>(cartDb);
    }

    public void Update(Cart cart)
    {
        var cartDb = _mapper.Map<CartDb>(cart);
        _repository.Update(cartDb);
    }

    public void Create(Cart cart)
    {
        var cartDb = _mapper.Map<CartDb>(cart);
        _repository.Create(cartDb);
    }

    public void AddItem(AddItemCommand command)
    {
        var cartDb = _repository.Get(command.CartId);
        if (cartDb is null)
        {
            cartDb = _mapper.Map<CartDb>(command);
            _repository.Create(cartDb);
            return;
        }

        ValidateAdd(command, cartDb);

        var itemDb = _mapper.Map<CartItemDb>(command);
        cartDb.Items.Add(itemDb);
        _repository.Update(cartDb);
    }

    private void ValidateAdd(AddItemCommand command, CartDb cartDb)
    {
        if (cartDb.Items.Exists(i => i.Id == command.Item.Id))
        {
            throw new ValidationException($"Cart {command.CartId} already has item {command.Item.Id}");
        }
    }

    public void RemoveItem(RemoveItemCommand command)
    {
        var cartDb = _repository.Get(command.CartId);

        ValidateRemove(command, cartDb);

        cartDb.Items.RemoveAll(i => i.Id == command.ItemId);
        _repository.Update(cartDb);
    }

    private static void ValidateRemove(RemoveItemCommand command, CartDb cartDb)
    {
        if (cartDb is null)
        {
            throw new ValidationException($"Cart {command.CartId} does not exist");
        }
        if (!cartDb.Items.Exists(i => i.Id == command.ItemId))
        {
            throw new ValidationException($"Cart {command.CartId} has no item {command.ItemId}");
        }
    }

    public void UpdateAllItemOccurences(UpdateAllItemOccurencesCommand command)
    {
        var carts = _repository.GetCartsWithItem(command.Id);
        foreach (var cart in carts)
        {
            var itemToUpdate = cart.Items.Single(i => i.Id == command.Id);
            _mapper.Map(command, itemToUpdate);
        }

        _repository.Update(carts);
    }
}
