using AutoMapper;
using Azure.Messaging.ServiceBus;
using Domain.Items;
using Newtonsoft.Json;

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

        public async Task PublishUpdatedAsync(Item item)
        {
            var itemMessage = _mapper.Map<ItemUpdatedMessage>(item);
            var body = JsonConvert.SerializeObject(itemMessage, _converter);
            var message = new ServiceBusMessage(body)
            {
                ContentType = "application/json"
            };
            await _sender.SendMessageAsync(message);
        }
    }
}
