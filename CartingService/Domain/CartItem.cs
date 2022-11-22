namespace Domain;

public record CartItem(Guid Id, string Name, decimal Price, int Quantity, Image Image)
{
    public CartItem() : this(default, "", default, default, default) { }
}
