using AutoMapper;
using Domain.Categories;

namespace Infrastructure.Sql.Categories;

internal class CategoryRepository : RepositoryIdBase<Category, CategoryDb>, ICategoryRepository
{
    public CategoryRepository(CatalogContext dbContext, IMapper mapper)
        : base(dbContext, dbContext.Categories, mapper) { }
}
