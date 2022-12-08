using AutoMapper;
using Infrastructure.Sql.Configuration;

namespace Infrastructure.Sql.Tests.Unit;

public class ConfigurationTests
{
    [Fact(DisplayName = "Automapper configuration is valid")]
    public void AutomapperConfigurationIsValid()
    {
        new MapperConfiguration(mc => mc.AddProfile(new ServiceBusProfile()))
           .CreateMapper().ConfigurationProvider.AssertConfigurationIsValid();
    }
}