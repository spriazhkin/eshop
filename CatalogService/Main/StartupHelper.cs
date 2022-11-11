using Api.Configuration;
using Api.Validators;
using Domain.Categories;
using Domain.Items;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        services.AddAutoMapper(typeof(SqlProfile), typeof(ApiProfile));
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IItemFacade, ItemFacade>();
        services.AddScoped<ICategoryFacade, CategoryFacade>();
    }
}
