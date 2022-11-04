using AutoMapper;
using Domain.Items;
using Infrastructure.Sql.Configuration;
using Infrastructure.Sql.Items;

namespace Infrastructure.Sql.Tests.Integration
{
    public class ItemRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly IMapper _mapper;
        private readonly Guid _guid = new("a9967493-3f16-49f2-bbf5-a796932cbfa7");

        public ItemRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new SqlProfile())).CreateMapper();
            using var context = _fixture.CreateContext();
            context.Items.RemoveRange(context.Items);
            context.SaveChanges();
        }

        [Fact(DisplayName = "Able to get created item")]
        public async Task TestCreate()
        {
            var item = new Item() { Id = _guid, Name = "test" };
            using var context = _fixture.CreateContext();
            var repo = new ItemRepository(context, _mapper);

            await repo.CreateAsync(item);
            var actualItem = await repo.GetAsync(_guid);

            Assert.Equal(item, actualItem);
        }
    }
}