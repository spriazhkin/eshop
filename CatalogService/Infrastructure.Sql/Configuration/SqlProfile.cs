using AutoMapper;
using Domain.Categories;
using Domain.Items;
using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Items;

namespace Infrastructure.Sql.Configuration
{
    public class SqlProfile : Profile
    {
        public SqlProfile()
        {
            CreateMap<Category, CategoryDb>();
            CreateMap<CategoryDb, Category>();

            CreateMap<Item, ItemDb>();
            CreateMap<ItemDb, Item>();
        }
    }
}
