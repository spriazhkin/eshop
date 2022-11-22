namespace Domain.Commands;

public record AddItemCommand(string CartId, CartItem Item)
{
    public AddItemCommand() : this("", default) { }
}
