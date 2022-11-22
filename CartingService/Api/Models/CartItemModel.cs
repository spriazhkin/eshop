namespace Api.Models;

public record CartItemModel(Guid Id, string Name, decimal Price, int Quantity, ImageModel Image)
{
    public CartItemModel() : this(default, "", default, default, default) { }
}
