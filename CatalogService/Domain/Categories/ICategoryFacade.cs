﻿namespace Domain.Categories;

public interface ICategoryFacade
{
    Task CreateAsync(Category category);

    Task DeleteAsync(Guid Id);

    Task<IList<Category>> GetAsync();

    Task<Category> GetAsync(Guid Id);

    Task UpdateAsync(Category category);
}