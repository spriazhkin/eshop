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

    /// <summary>
    /// Get Cart items
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IList<CartItemModel> Get([FromRoute] Guid id)
    {
        var cart = _facade.Get(id);
        return _mapper.Map<IList<CartItemModel>>(cart);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartModel"></param>
    /// <remarks>Same as v1</remarks>
    [HttpPost]
    public virtual void Create([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Create(cart);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartModel"></param>
    /// <remarks>Same as v1</remarks>
    [HttpPut]
    public virtual void Update([FromBody] CartModel cartModel)
    {
        var cart = _mapper.Map<Cart>(cartModel);
        _facade.Update(cart);
    }
}
