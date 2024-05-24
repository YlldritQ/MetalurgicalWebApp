using AutoMapper;
using backend_dotnet7.Core.Dtos.Orders;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Product_Order;
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

            //Product_Order
            CreateMap<CreateUpdateProductOrderDto, Product_Order>()
     .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
     .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));

            CreateMap<Product_Order, CreateUpdateProductOrderDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));

        }
    }
}
