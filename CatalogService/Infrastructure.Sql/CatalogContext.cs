using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql;

internal class CatalogContext : DbContext
{
    public CatalogContext() : base()
    {
    }
    public CatalogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryDb> Categories { get; set; }

    public DbSet<ItemDb> Items { get; set; }
}
