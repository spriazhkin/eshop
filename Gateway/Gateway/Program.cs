using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = new WebHostBuilder();

builder.UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory());

builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config
        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        .AddJsonFile("ocelot.json")
        .AddEnvironmentVariables();
});

builder.ConfigureServices(s =>
{
    s.AddOcelot();
});

builder.ConfigureLogging((hostingContext, logging) =>
{
    //add your logging
});

builder.UseIISIntegration()
.Configure(app =>
{
    app.UseOcelot().Wait();
});


builder.Build()
    .Run();
