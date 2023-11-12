using Application.Features.Car.Common;
using Application.Features.Shop.Common;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<Shop, ShopResponse>();
        CreateMap<Shop, CreateShopResponse>();
        CreateMap<Shop, UpdateShopResponse>();

        CreateMap<Car, CarResponse>()
            .ForPath(dest => dest.Body, opt => opt.MapFrom(src => src.Body!.Name))
            .ForPath(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel!.Name))
            .ForPath(dest => dest.Gearbox, opt => opt.MapFrom(src => src.Gearbox!.Name))
            .ForPath(dest => dest.Model, opt => opt.MapFrom(src => src.Model!.Name));

        CreateMap<Car, CreateCarResponse>()
            .ForPath(dest => dest.Body, opt => opt.MapFrom(src => src.Body!.Name))
            .ForPath(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel!.Name))
            .ForPath(dest => dest.Gearbox, opt => opt.MapFrom(src => src.Gearbox!.Name))
            .ForPath(dest => dest.Model, opt => opt.MapFrom(src => src.Model!.Name));

        CreateMap<Car, UpdateCarResponse>()
            .ForPath(dest => dest.Body, opt => opt.MapFrom(src => src.Body!.Name))
            .ForPath(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel!.Name))
            .ForPath(dest => dest.Gearbox, opt => opt.MapFrom(src => src.Gearbox!.Name))
            .ForPath(dest => dest.Model, opt => opt.MapFrom(src => src.Model!.Name));

        //        CreateMap<Part, PartDto>();
    }
}
