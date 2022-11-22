using Api.Models;
using AutoMapper;
using Domain.Categories;
using Domain.Items;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Main")]

namespace Api.Configuration;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<ItemModel, Item>();
        CreateMap<Item, ItemModel>();

        CreateMap<CategoryModel, Category>();
        CreateMap<Category, CategoryModel>();
    }
}
