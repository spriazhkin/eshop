using Domain.Items;

namespace Infrastructure.Sql;

internal class ItemRepository : IItemRepository
{
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

    public Task<List<Item>> GetByCategoryIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Item item)
    {
        throw new NotImplementedException();
    }
}
