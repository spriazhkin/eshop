using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql.Tests.Integration;

public class DatabaseFixture
{
    private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=CatalogTests;Trusted_Connection=True;MultipleActiveResultSets=true";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public DatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }

                _databaseInitialized = true;
            }
        }
    }

    internal CatalogContext CreateContext()
        => new CatalogContext(
            new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}
