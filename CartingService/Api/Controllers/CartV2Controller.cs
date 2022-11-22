using Api.Models;
using Api.Models.Commands;
using AutoMapper;
using Domain;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/carts")]
[ApiVersion("2.0")]
public class CartV2Controller : ControllerBase
{
    private readonly ICartFacade _facade;
    private readonly IMapper _mapper;

    public CartV2Controller(ICartFacade facade, IMapper mapper)
    {
        _facade = facade;
        _mapper = mapper;
    }

    /// <summary>
    /// Get Cart items
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IList<CartItemModel> Get([FromRoute] string id)
    {
        var cart = _facade.Get(id);
        return _mapper.Map<IList<CartItemModel>>(cart);
    }

    /// <summary>
    /// Adds item to cart. Creates cart when it does not exist
    /// </summary>
    /// <param name="commandModel"></param>
    /// <remarks>Same as V1</remarks>
    [HttpPost("add-item")]
    public void AddItem([FromBody] AddItemCommandModel commandModel)
    {
        var command = _mapper.Map<AddItemCommand>(commandModel);
        _facade.AddItem(command);
    }

    /// <summary>
    /// Removes items from cart
    /// </summary>
    /// <param name="commandModel"></param>
    /// <remarks>Same as V1</remarks>
    [HttpPost("remove-item")]
    public void RemoveItem([FromBody] RemoveItemCommand commandModel)
    {
        var command = _mapper.Map<RemoveItemCommand>(commandModel);
        _facade.RemoveItem(command);
    }
}
