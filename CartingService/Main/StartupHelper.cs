using Api.Configuration;
using Api.Validators;
using Azure.Messaging.ServiceBus;
using DAL;
using Domain;
using Domain.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;
using ServiceBus;
using ServiceBus.Items;

namespace Main;

internal static class StartupHelper
{
    internal static void RegisterComponents(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CartModelValidator>();
        services.AddAutoMapper(typeof(DomainProfile), typeof(ApiProfile), typeof(ServiceBusProfile));
        services.AddTransient<ICartRepository, CartRepository>((s) => new CartRepository(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<ICartFacade, CartFacade>();
        services.AddSingleton(_ => new ServiceBusClient(configuration.GetConnectionString("ServiceBus")));
        services.AddSingleton(_ => new TypeInfoConverter(new List<Type> { typeof(ItemUpdatedMessage) }));
        services.AddHostedService<ItemsHandler>();
    }
}
