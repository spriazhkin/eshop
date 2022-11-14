using AutoMapper;
using Azure.Messaging.ServiceBus;
using Domain.Items;
using Newtonsoft.Json;

namespace Infrastructure.ServiceBus.Items
{
    internal class ItemPublisher : IItemPublisher
    {
        private const string QueueName = "items";
        private readonly IMapper _mapper;
        private readonly ServiceBusSender _sender;

        public ItemPublisher(IMapper mapper, ServiceBusClient client)
        {
            _mapper = mapper;
            _sender = client.CreateSender(QueueName);
        }

        public async Task PublishUpdatedAsync(Item item)
        {
            var itemMessage = _mapper.Map<ItemUpdatedMessage>(item);
            var body = JsonConvert.SerializeObject(itemMessage);
            var message = new ServiceBusMessage(body)
            {
                ContentType = "application/json"
            };
            await _sender.SendMessageAsync(message);
        }
    }
}
