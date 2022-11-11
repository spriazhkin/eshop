using AutoMapper;
using Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql.Items;

internal class ItemRepository : RepositoryIdBase<Item, ItemDb>, IItemRepository
{
    private readonly IMapper _mapper;

    public ItemRepository(CatalogContext dbContext, IMapper mapper)
        : base(dbContext, dbContext.Items, mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<Item>> GetByCategoryIdAsync(Guid categoryId, int limit, int offset)
    {
        var itemsDb = await GetIQueryable()
            .AsNoTracking()
            .Where(i => i.CategoryId == categoryId)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();

        return _mapper.Map<List<Item>>(itemsDb);
    }
}
