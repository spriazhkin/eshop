namespace Domain.Items
{
    public interface IItemPublisher
    {
        Task PublishUpdatedAsync(Item item);
    }
}
