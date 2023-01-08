using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;

var builder = new WebHostBuilder();

builder.UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory());

builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config
        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        .AddOcelot(hostingContext.HostingEnvironment)
        .AddEnvironmentVariables();
});

builder.ConfigureServices(s =>
{
    s.AddOcelot()
        .AddCacheManager(x =>
        {
            x.WithDictionaryHandle();
        });
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
