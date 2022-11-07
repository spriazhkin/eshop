namespace Api.Models.Commands;

public record RemoveItemCommandModel(string CartId, int ItemId)
{
    public RemoveItemCommandModel() : this("", default) { }
}
