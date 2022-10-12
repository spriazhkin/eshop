using AutoMapper;

namespace Domain.Tests;

public class ConfigurationTests
{
    [Fact(DisplayName = "Automapper configuration is valid")]
    public void AutomapperConfigurationIsValid()
    {
        new MapperConfiguration(mc => mc.AddProfile(new DomainProfile()))
           .CreateMapper().ConfigurationProvider.AssertConfigurationIsValid();
    }
}