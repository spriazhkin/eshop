namespace Domain;

public record Cart
{
    public Guid Id { get; init; }

    public IList<CartItem> Items { get; init; } = new List<CartItem>();
}
