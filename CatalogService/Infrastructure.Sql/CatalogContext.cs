using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql;

internal class CatalogContext : DbContext
{
    private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=CatalogDb;Trusted_Connection=True;MultipleActiveResultSets=true";

    public CatalogContext() : this(new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(ConnectionString).Options)
    {
    }

    public CatalogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryDb> Categories { get; set; }

    public DbSet<ItemDb> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CategoryDb>()
            .HasOne<CategoryDb>()
            .WithMany()
            .HasForeignKey(c => c.ParentId);

        modelBuilder.Entity<ItemDb>(e =>
        {
            e.HasOne<CategoryDb>()
            .WithMany()
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            e.Property(c => c.Price)
            .HasPrecision(10, 2);
        });
    }
}
