using Api.Configuration;
using Api.Validators;
using Azure.Messaging.ServiceBus;
using Domain.Categories;
using Domain.Items;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.ServiceBus;
using Infrastructure.ServiceBus.Items;
using Infrastructure.Sql;
using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Configuration;
using Infrastructure.Sql.Items;
using Microsoft.EntityFrameworkCore;

namespace Main;

internal static class StartupHelper
{
    internal static void RegisterComponents(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CategoryModelValidator>();
        services.AddAutoMapper(typeof(SqlProfile), typeof(ApiProfile), typeof(ServiceBusProfile));
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IItemFacade, ItemFacade>();
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<IItemPublisher, ItemPublisher>();
        services.AddSingleton(_ => new TypeInfoConverter(new List<Type> { typeof(ItemUpdatedMessage) }));
        services.AddScoped(_ => new ServiceBusClient(configuration.GetConnectionString("ServiceBus")));
    }
}
