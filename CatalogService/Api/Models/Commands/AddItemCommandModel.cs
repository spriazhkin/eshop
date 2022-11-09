namespace Api.Models.Commands;

public record AddItemCommandModel(string CartId, ItemModel Item)
{
    public AddItemCommandModel() : this("", default) { }
}
