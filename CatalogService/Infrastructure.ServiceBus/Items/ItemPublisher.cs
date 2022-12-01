using AutoMapper;
using Azure.Messaging.ServiceBus;
using Domain.Items;
using Newtonsoft.Json;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace Infrastructure.ServiceBus.Items
{
    internal class ItemPublisher : IItemPublisher, IAsyncDisposable
    {
        private const string QueueName = "items";
        private readonly IMapper _mapper;
        private readonly ServiceBusSender _sender;
        private readonly TypeInfoConverter _converter;

        public ItemPublisher(
            IMapper mapper,
            ServiceBusClient client,
            TypeInfoConverter converter)
        {
            _mapper = mapper;
            _sender = client.CreateSender(QueueName);
            _converter = converter;
        }

        public async ValueTask DisposeAsync()
        {
            await _sender.DisposeAsync();
        }

        private async Task PublishMessage<T>(object entity)
        {
            var itemMessage = _mapper.Map<T>(entity);
            var body = JsonConvert.SerializeObject(itemMessage, _converter);
            var message = new ServiceBusMessage(body)
            {
                ContentType = "application/json"
            };

            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);
            var policy = Policy.Handle<ServiceBusException>()
                .WaitAndRetryAsync(delay);

            await policy.ExecuteAsync(() => _sender.SendMessageAsync(message));
        }

        public Task PublishUpdatedAsync(Item item) => PublishMessage<ItemUpdatedMessage>(item);
    }
}
