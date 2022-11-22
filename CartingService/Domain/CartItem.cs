namespace Domain;

public record CartItem(int Id, string Name, decimal Price, int Quantity, Image Image)
{
    public CartItem() : this(default, "", default, default, default) { }
}
