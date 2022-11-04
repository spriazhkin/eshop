using AutoMapper;
using DAL;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Main")]

namespace Domain.Configuration;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Cart, CartDb>();
        CreateMap<CartDb, Cart>();

        CreateMap<CartItemDb, CartItem>();
        CreateMap<CartItem, CartItemDb>();

        CreateMap<Image, ImageDb>();
        CreateMap<ImageDb, Image>();
    }
}
