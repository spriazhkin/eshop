using AutoMapper;
using DAL;
using Domain.Commands;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Main")]

namespace Domain.Configuration;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Cart, CartDb>();
        CreateMap<CartDb, Cart>();

        CreateMap<CartItemDb, CartItem>();
        CreateMap<CartItem, CartItemDb>();

        CreateMap<AddItemCommand, CartItemDb>()
            .ConvertUsing((src, _, context) => context.Mapper.Map<CartItemDb>(src.Item));

        CreateMap<AddItemCommand, CartDb>()
            .ForMember(dest => dest.Items, opt =>
                opt.MapFrom((src, _, _, context) =>
                    new List<CartItemDb>() { context.Mapper.Map<CartItemDb>(src) }))
            .ForMember(dest => dest.Id, opt =>
                opt.MapFrom(src => src.CartId));

        CreateMap<Image, ImageDb>();
        CreateMap<ImageDb, Image>();
    }
}
