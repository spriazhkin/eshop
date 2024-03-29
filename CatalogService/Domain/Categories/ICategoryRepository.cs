﻿namespace Domain.Categories;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);

    Task DeleteAsync(Guid Id);

    Task<IList<Category>> GetAsync();

    Task<Category> GetAsync(Guid Id);
    
    Task<(Category entity, bool found)> TryGetAsync(Guid value);

    Task UpdateAsync(Category category);
}