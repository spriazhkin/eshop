using AutoMapper;
using Domain.Configuration;

namespace Api.Tests.Unit;

public class ConfigurationTests
{
    [Fact(DisplayName = "Automapper configuration is valid")]
    public void AutomapperConfigurationIsValid()
    {
        new MapperConfiguration(mc => mc.AddProfile(new ServiceBusProfile()))
           .CreateMapper().ConfigurationProvider.AssertConfigurationIsValid();
    }
}