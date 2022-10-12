namespace Domain;

public record CartItem
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public Image? Image { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; set; }
}
