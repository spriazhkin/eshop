using AutoMapper;
using Domain.Commands;
using ServiceBus.Items;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Main")]

namespace Domain.Configuration;

public class ServiceBusProfile : Profile
{
    public ServiceBusProfile()
    {
        CreateMap<ItemUpdatedMessage, UpdateAllItemOccurencesCommand>();
    }
}
