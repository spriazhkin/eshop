using Api.Configuration;
using AutoMapper;

namespace Infrastructure.Sql.Tests.Unit;

public class ConfigurationTests
{
    [Fact(DisplayName = "Automapper configuration is valid")]
    public void AutomapperConfigurationIsValid()
    {
        new MapperConfiguration(mc => mc.AddProfile(new ApiProfile()))
           .CreateMapper().ConfigurationProvider.AssertConfigurationIsValid();
    }
}