namespace Domain.Items;

public interface IItemFacade
{
    Task<Item> GetAsync(Guid Id);

    Task<Dictionary<string, string>> GetPropertiesAsync(Guid itemId);

    Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset);

    Task CreateAsync(Item item);

    Task UpdateAsync(Item item);

    Task DeleteAsync(Guid Id);
}