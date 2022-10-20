using AutoMapper;
using Domain.Items;
using Infrastructure.Sql.Configuration;
using Infrastructure.Sql.Items;
using System.Data.Common;

namespace Infrastructure.Sql.Tests.Integration
{
    public class UnitTest1
    {
        private readonly Guid _guid = new("a9967493-3f16-49f2-bbf5-a796932cbfa7");

        [Fact]
        public async Task Test1()
        {
            using var context = new CatalogContext();
            var mapper = new MapperConfiguration(mc => mc.AddProfile(new SqlProfile())).CreateMapper();
            var repo = new ItemRepository(context, mapper);

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var item = new Item() { Name = "test" };
            await repo.CreateAsync(item);
            var item2 = await repo.GetAsync(_guid);

            Assert.Equal(item, item2);
        }
    }
}