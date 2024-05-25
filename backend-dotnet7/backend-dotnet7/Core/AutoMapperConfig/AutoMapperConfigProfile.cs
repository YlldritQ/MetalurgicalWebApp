using AutoMapper;
using backend_dotnet7.Core.Dtos.Location;
using backend_dotnet7.Core.Dtos.Orders;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Product_Order;
using backend_dotnet7.Core.Dtos.TerminLocation;
using backend_dotnet7.Core.Entities;

namespace backend_dotnet7.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {
            //Product
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<Product, CreateUpdateProductDto>();

            //Orders
            CreateMap<CreateUpdateOrderDto, OrderEntity>();
            CreateMap<OrderEntity, CreateUpdateOrderDto>();

            //Termin
            CreateMap<TerminLocationDto, Termin>();
            CreateMap<Termin, TerminLocationDto>();

            //Location
            CreateMap<TerminLocationDto, Location>();
            CreateMap<Location, TerminLocationDto>();

            //Product_Order
            CreateMap<CreateUpdateProductOrderDto, Product_Order>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));

            CreateMap<Product_Order, CreateUpdateProductOrderDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));

            //TerminLocation
            CreateMap<TerminLocationDto, TerminLocation>()
     .ForMember(dest => dest.TerminId, opt => opt.MapFrom(src => src.TerminId))
     .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId));

            CreateMap<TerminLocation, TerminLocationDto>()
                .ForMember(dest => dest.TerminId, opt => opt.MapFrom(src => src.TerminId))
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId));
        }
    }
}
