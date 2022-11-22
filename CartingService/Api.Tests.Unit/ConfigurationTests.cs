using Api.Configuration;
using AutoMapper;

namespace Api.Tests.Unit;

public class ConfigurationTests
{
    [Fact(DisplayName = "Automapper configuration is valid")]
    public void AutomapperConfigurationIsValid()
    {
        new MapperConfiguration(mc => mc.AddProfile(new ApiProfile()))
           .CreateMapper().ConfigurationProvider.AssertConfigurationIsValid();
    }
}