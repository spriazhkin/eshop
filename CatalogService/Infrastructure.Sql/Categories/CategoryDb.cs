namespace Infrastructure.Sql.Categories;

public record CategoryDb : IEntityDb
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string ImageUrl { get; init; }

    public Guid? ParentId { get; init; }
}