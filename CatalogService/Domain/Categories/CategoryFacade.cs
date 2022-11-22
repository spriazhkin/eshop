using Domain.Exceptions;

namespace Domain.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly ICategoryRepository _repository;

    public CategoryFacade(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Category category)
    {
        await ValidateAsync(category);
        await _repository.CreateAsync(category);
    }

    public Task DeleteAsync(Guid Id) => _repository.DeleteAsync(Id);

    public Task<Category> GetAsync(Guid Id) => _repository.GetAsync(Id);

    public Task<IList<Category>> GetAsync() => _repository.GetAsync();

    public async Task UpdateAsync(Category category)
    {
        await ValidateAsync(category);
        await _repository.UpdateAsync(category);
    }

    private async Task ValidateAsync(Category category)
    {
        if (category.ParentId.HasValue)
        {
            var (_, found) = await _repository.TryGetAsync(category.ParentId.Value);
            if (!found)
            {
                throw new ValidationException($"Parent category {category.ParentId.Value} does not exists");
            }
        }
    }
}
