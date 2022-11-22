namespace Api.Models.Commands;

public record RemoveItemCommandModel(string CartId, Guid ItemId)
{
    public RemoveItemCommandModel() : this("", default) { }
}
