namespace DAL;

public record CartItemDb
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public ImageDb? Image { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; set; }
}
