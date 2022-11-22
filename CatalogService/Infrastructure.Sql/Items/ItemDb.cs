namespace Infrastructure.Sql.Items;

public record ItemDb(Guid Id, string Name, string Description, string Image,
    Guid CategoryId, decimal Price, int Amount) : IEntityDb
{
}
