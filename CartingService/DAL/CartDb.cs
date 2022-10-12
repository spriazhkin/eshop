namespace DAL;

public record CartDb
{
    public Guid Id { get; init; }

    public List<CartItemDb> Items { get; init; } = new List<CartItemDb>();
}
