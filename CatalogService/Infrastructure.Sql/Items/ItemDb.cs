namespace Infrastructure.Sql.Items;

public record ItemDb : IEntityDb
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }
}
