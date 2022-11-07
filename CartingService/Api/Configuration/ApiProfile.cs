using Api.Models;
using Api.Models.Commands;
using AutoMapper;
using Domain;
using Domain.Commands;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Main")]

namespace Api.Configuration;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Image, ImageModel>();
        CreateMap<ImageModel, Image>();

        CreateMap<CartItemModel, CartItem>();
        CreateMap<CartItem, CartItemModel>();

        CreateMap<Cart, CartModel>();
        CreateMap<CartModel, Cart>();
        CreateMap<Cart, IList<CartItemModel>>()
            .ConvertUsing((cart, _, context) =>
                context.Mapper.Map<IList<CartItemModel>>(cart.Items));

        CreateMap<RemoveItemCommandModel, RemoveItemCommand>();
        CreateMap<AddItemCommandModel, AddItemCommand>();
    }
}
