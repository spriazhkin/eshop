using AutoMapper;
using Domain.Categories;
using Domain.Items;
using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Configuration;
using Infrastructure.Sql.Items;

namespace Infrastructure.Sql.Tests.Integration
{
    public class ItemRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly IMapper _mapper;
        private readonly Guid _guid = new("a9867493-3f16-49f2-bbf5-a796932cbfa7");
        private readonly Guid _categoryId = new("b3867493-3f16-49f2-bbf5-a796932cccc6");

        public ItemRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new SqlProfile())).CreateMapper();
            using var context = _fixture.CreateContext();
            context.Categories.RemoveRange(context.Categories);
            context.Items.RemoveRange(context.Items);

            context.SaveChanges();

            var category = new Category() { Id = _categoryId };
            var categoryRepo = new CategoryRepository(context, _mapper);
            categoryRepo.CreateAsync(category).Wait();
        }

        [Fact(DisplayName = "Able to get created item")]
        public async Task TestCreate()
        {
            var item = new Item() { Id = _guid, Name = "test", CategoryId = _categoryId };
            using var context = _fixture.CreateContext();

            var repo = new ItemRepository(context, _mapper);

            await repo.CreateAsync(item);
            var actualItem = await repo.GetAsync(_guid);

            Assert.Equal(item, actualItem);
        }

        [Fact(DisplayName = "Able to update item")]//, Skip = "Concurrency issues")]
        public async Task TestUdpate()
        {
            var item = new Item() { Id = _guid, Name = "test", CategoryId = _categoryId };
            var updatedItem = item with { Name = "test2" };

            using var context = _fixture.CreateContext();
            var repo = new ItemRepository(context, _mapper);

            await repo.CreateAsync(item);
            await repo.UpdateAsync(updatedItem);

            var actualItem = await repo.GetAsync(_guid);
           
            Assert.Equal(updatedItem, actualItem);
        }
    }
}