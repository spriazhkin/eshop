namespace ServiceBus.Items;

internal record ItemUpdatedMessage(Guid Id, string Name, string Description, string Image,
    decimal Price, int Amount)
{
    public ItemUpdatedMessage() : this(default, "", "", "", default, default) { }
}
