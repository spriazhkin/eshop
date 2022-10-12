namespace Domain;

public record Cart
{
    public Guid Id { get; init; }

    public List<CartItem> Items { get; init; } = new List<CartItem>();
}
