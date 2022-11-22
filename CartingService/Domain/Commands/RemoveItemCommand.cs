namespace Domain.Commands;

public record RemoveItemCommand
{
    public RemoveItemCommand(string cartId, int itemId)
    {
        CartId = cartId ?? throw new ArgumentNullException(nameof(cartId));
        ItemId = itemId;
    }

    public string CartId { get; set; }

    public int ItemId { get; set; }
}
