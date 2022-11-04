using Api.Configuration;
using Api.Models;
using Api.Validators;
using DAL;
using Domain;
using Domain.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Main;

internal static class StartupHelper
{
    internal static void RegisterComponents(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CartModelValidator>();
        services.AddAutoMapper(typeof(DomainProfile), typeof(ApiProfile));
        services.AddScoped<ICartRepository, CartRepository>((s) => new CartRepository(@"C:\Temp\Cart.db"));
        services.AddScoped<ICartFacade, CartFacade>();
    }
}
