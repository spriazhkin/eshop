using Api.Configuration;
using Api.Controllers;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Filters.Add<ExceptionHandlingAttribute>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var basePath = PlatformServices.Default.Application.ApplicationBasePath;
var fileName = typeof(CartV1Controller).GetTypeInfo().Assembly.GetName().Name + ".xml";

var XmlCommentsFilePath = Path.Combine(basePath, fileName);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v0", new OpenApiInfo { Title = "My API - V0", Version = "v0" });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API - V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });

    c.IncludeXmlComments(XmlCommentsFilePath);

});

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

Main.StartupHelper.RegisterComponents(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v0/swagger.json", "Carting API - V0");
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Carting API - V1");
        c.SwaggerEndpoint($"/swagger/v2/swagger.json", "Carting API - V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
