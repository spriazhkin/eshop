using Api.Models;
using Api.Models.Commands;
using AutoMapper;
using Domain;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/carts")]
[ApiVersion("1.0")]
public class CartV1Controller : ControllerBase
{
    private readonly ICartFacade _facade;
    private readonly IMapper _mapper;

    public CartV1Controller(ICartFacade facade, IMapper mapper)
    {
        _facade = facade;
        _mapper = mapper;
    }

    /// <summary>
    /// Get Cart
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public CartModel Get([FromRoute] string id)
    {
        var cart = _facade.Get(id);
        return _mapper.Map<CartModel>(cart);
    }

    /// <summary>
    /// Adds item to cart. Creates cart when it does not exist
    /// </summary>
    /// <param name="commandModel"></param>
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
    [HttpPost("remove-item")]
    public void RemoveItem([FromBody] RemoveItemCommand commandModel)
    {
        var command = _mapper.Map<RemoveItemCommand>(commandModel);
        _facade.RemoveItem(command);
    }
}
