namespace Domain.Commands;

public record AddItemCommand
{
    public AddItemCommand(string cartId, CartItem item)
    {
        CartId = cartId ?? throw new ArgumentNullException(nameof(cartId));
        Item = item ?? throw new ArgumentNullException(nameof(item));
    }

    public string CartId { get; set; }

    public CartItem Item { get; set; }
}
