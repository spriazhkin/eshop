using AutoMapper;
using Azure.Messaging.ServiceBus;
using Domain;
using Domain.Commands;
using Microsoft.Extensions.Logging;
using Usga.Deacon.Tools.MessageBroker;

namespace ServiceBus.Items
{
    internal class ItemsHandler : HandlerBase
    {
        private readonly ICartFacade _facade;
        private readonly IMapper _mapper;

        public ItemsHandler(
            ServiceBusClient client,
            ILogger<ItemsHandler> logger,
            TypeInfoConverter converter,
            ICartFacade facade,
            IMapper mapper) : base(client, logger, converter)
        {
            _facade = facade;
            _mapper = mapper;
        }

        protected override string Topic => "Items";

        public void Handle(ItemUpdatedMessage message)
        {
            var command = _mapper.Map<UpdateAllItemOccurencesCommand>(message);
            _facade.UpdateAllItemOccurences(command);
        }
    }
}
