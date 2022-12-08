using AutoMapper;
using Domain.Items;
using Infrastructure.ServiceBus.Items;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Infrastructure.ServiceBus.Tests.Unit")]
[assembly: InternalsVisibleTo("Main")]

namespace Infrastructure.Sql.Configuration;

public class ServiceBusProfile : Profile
{
    public ServiceBusProfile()
    {
        CreateMap<Item, ItemUpdatedMessage>();
    }
}
