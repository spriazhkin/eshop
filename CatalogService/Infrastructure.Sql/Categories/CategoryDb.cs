namespace Infrastructure.Sql.Categories;

public record CategoryDb(Guid Id, string Name, string ImageUrl, Guid? ParentId) : IEntityDb
{
}