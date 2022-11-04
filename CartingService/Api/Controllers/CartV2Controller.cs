using Api.Models;
using AutoMapper;
using Domain;
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

    [HttpGet("{id}")]
    public IList<CartItemModel> Get([FromRoute] Guid id)
    {
        var cart = _facade.Get(id);
        return _mapper.Map<IList<CartItemModel>>(cart);
    }

    [HttpPost]
    public virtual void Create([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Create(cart);
    }

    [HttpPut]
    public virtual void Update([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Update(cart);
    }
}
