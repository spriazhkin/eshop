using AutoMapper;
using DAL;

namespace Domain;

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
