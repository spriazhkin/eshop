using Api.Models;
using AutoMapper;
using Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Main")]

namespace Api.Configuration;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Cart, CartModel>();
        CreateMap<CartModel, Cart>();

        CreateMap<CartItemModel, CartItem>();
        CreateMap<CartItem, CartItemModel>();

        CreateMap<Image, ImageModel>();
        CreateMap<ImageModel, Image>();
    }
}
