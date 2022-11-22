﻿using Domain.Categories;
using System.ComponentModel.DataAnnotations;

namespace Domain.Items;

internal class ItemFacade : IItemFacade
{
    private readonly IItemRepository _repository;
    private readonly ICategoryRepository _categoryRepository;

    public ItemFacade(IItemRepository repository, ICategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(Item item)
    {
        await ValidateAsync(item);
        await _repository.CreateAsync(item);
    }

    public Task DeleteAsync(Guid Id) => _repository.DeleteAsync(Id);

    public Task<Item> GetAsync(Guid Id) => _repository.GetAsync(Id);

    public Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset)
        => _repository.GetByCategoryIdAsync(categoryId, limit, offset);

    public async Task UpdateAsync(Item item)
    {
        await ValidateAsync(item);
        await _repository.UpdateAsync(item);
    }

    private async Task ValidateAsync(Item item)
    {
        var (_, found) = await _categoryRepository.TryGetAsync(item.CategoryId);
        if (!found)
        {
            throw new ValidationException($"Item category {item.CategoryId} does not exists");
        }
    }
}
