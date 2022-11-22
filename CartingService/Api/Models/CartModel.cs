namespace Api.Models;

public record CartModel(string Id, List<CartItemModel> Items)
{
    public CartModel() : this("", default) { }
}
