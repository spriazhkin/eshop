namespace DAL;

public record CartItemDb(Guid Id, string Name, decimal Price, int Quantity, ImageDb Image = null)
{
    public CartItemDb() : this(default, default, default, default, default) { }
}
