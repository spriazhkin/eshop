using Api.Models;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/carts")]
[ApiVersion("0")]
public class CartV0Controller : ControllerBase
{
    private readonly ICartFacade _facade;
    private readonly IMapper _mapper;

    public CartV0Controller(ICartFacade facade, IMapper mapper)
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
    /// 
    /// </summary>
    /// <param name="cartModel"></param>
    [HttpPost]
    public void Create([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Create(cart);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartModel"></param>
    [HttpPut]
    public void Update([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Update(cart);
    }
}
