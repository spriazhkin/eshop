namespace Domain.Items;

public interface IItemFacade
{
    Task<Item> GetAsync(Guid Id);

    Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset);

    Task CreateAsync(Item item);

    Task UpdateAsync(Item item);

    Task DeleteAsync(Guid Id);
}