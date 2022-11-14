using Api.Models;
using AutoMapper;
using Domain.Items;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly IItemFacade _facade;
    private readonly IMapper _mapper;

    public ItemController(IItemFacade facade, IMapper mapper)
    {
        _facade = facade;
        _mapper = mapper;
    }

    /// <summary>
    /// Get items
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<ItemModel>> GetAsync(Guid categoryId, int limit, int offset = 0)
    {
        var item = await _facade.GetByCategoryIdAsync(categoryId, limit, offset);
        return _mapper.Map<List<ItemModel>>(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ItemModel> GetAsync([FromRoute] Guid id)
    {
        var item = await _facade.GetAsync(id);
        return _mapper.Map<ItemModel>(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemModel"></param>
    [HttpPost]
    public async Task CreateAsync([FromBody] ItemModel itemModel)
    {
        var item = _mapper.Map<Item>(itemModel);
        await _facade.CreateAsync(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemModel"></param>
    [HttpPut]
    public async Task UpdateAsync([FromBody] ItemModel itemModel)
    {
        var item = _mapper.Map<Item>(itemModel);
        await _facade.UpdateAsync(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync([FromRoute] Guid id)
    {
        await _facade.DeleteAsync(id);
    }
}
