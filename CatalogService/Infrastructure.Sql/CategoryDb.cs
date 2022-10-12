namespace Infrastructure.Sql;

public record CategoryDb
{
    public Guid Id { get; set; }

    public string Name { get; init; } = string.Empty;

    public string? ImageUrl { get; init; }

    public Guid? ParentId { get; init; }
}