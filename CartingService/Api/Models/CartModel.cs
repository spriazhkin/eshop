namespace Api.Models;

public record CartModel
{
    public Guid Id { get; init; }

    public List<CartItemModel> Items { get; init; } = new List<CartItemModel>();
}
