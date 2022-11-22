namespace Api.Models.Commands;

public record AddItemCommandModel(string CartId, CartItemModel Item)
{
    public AddItemCommandModel() : this("", default) { }
}
