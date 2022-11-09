namespace Domain.Items;

public record Item(Guid Id, string Name, string Description, string Image,
    Guid CategoryId, decimal Price, int Amount)
{
    public Item(): this(default, "", "", "", default, default, default) { }
}
