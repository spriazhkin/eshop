namespace Api.Models;

public record ItemModel(int Id, string Name, decimal Price, int Quantity)
{
    public ItemModel() : this(default, "", default, default) { }
}
