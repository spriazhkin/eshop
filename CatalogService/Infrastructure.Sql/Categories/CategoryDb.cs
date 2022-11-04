namespace Infrastructure.Sql.Categories;

public record CategoryDb : IEntityDb
{
    public Guid Id { get; set; }

    public string Name { get; init; } = string.Empty;

    public string? ImageUrl { get; init; }

    public Guid? ParentId { get; init; }
}