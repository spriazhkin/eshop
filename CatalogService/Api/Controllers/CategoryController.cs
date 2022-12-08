using Api.Models;
using AutoMapper;
using Domain.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryFacade _facade;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryFacade facade, IMapper mapper)
    {
        _facade = facade;
        _mapper = mapper;
    }

    /// <summary>
    /// Get categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<CategoryModel>> GetAsync()
    {
        var category = await _facade.GetAsync();
        return _mapper.Map<List<CategoryModel>>(category);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryModel"></param>
    [HttpPost]
    public async Task CreateAsync([FromBody] CategoryModel categoryModel)
    {
        var category = _mapper.Map<Category>(categoryModel);
        await _facade.CreateAsync(category);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryModel"></param>
    [HttpPut]
    public async Task UpdateAsync([FromBody] CategoryModel categoryModel)
    {
        var category = _mapper.Map<Category>(categoryModel);
        await _facade.UpdateAsync(category);
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
