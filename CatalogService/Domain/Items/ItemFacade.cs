namespace Domain.Items;

internal class ItemFacade : IItemFacade
{
    private readonly IItemRepository _repository;

    public ItemFacade(IItemRepository repository)
    {
        _repository = repository;
    }

    public Task CreateAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Item item)
    {
        throw new NotImplementedException();
    }
}
