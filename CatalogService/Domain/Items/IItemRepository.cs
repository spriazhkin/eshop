namespace Domain.Items;

public interface IItemRepository
{
    Task CreateAsync(Item item);
    
    Task DeleteAsync(Guid Id);
    
    Task<Item> GetAsync(Guid Id);
    
    Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset);
    
    Task UpdateAsync(Item item);
}