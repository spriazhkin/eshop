using AutoMapper;
using DAL;
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

    public Cart Get(Guid id)
    {
        var cartDb = _repository.Get(id);
        if (cartDb is null)
        {
            throw new EntityNotFoundException($"Cart with id {id} does not exist");
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
}
