namespace Api.Models;

public record CartItemModel
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public ImageModel? Image { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; set; }
}
