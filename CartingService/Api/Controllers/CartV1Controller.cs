using Api.Models;
using AutoMapper;
using Domain;
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

    [HttpGet("{id}")]
    public CartModel Get([FromRoute] Guid id)
    {
        var cart = _facade.Get(id);
        return _mapper.Map<CartModel>(cart);
    }

    [HttpPost]
    public void Create([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Create(cart);
    }

    [HttpPut]
    public void Update([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Update(cart);
    }
}
