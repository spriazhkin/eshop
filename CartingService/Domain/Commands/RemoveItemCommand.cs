namespace Domain.Commands;

public record RemoveItemCommand(string CartId, Guid ItemId)
{
    public RemoveItemCommand() : this("", default) { }
}
