using AutoMapper;
using backend_dotnet7.Core.Dtos.Orders;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Termin;
using backend_dotnet7.Core.Entities;

namespace backend_dotnet7.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {
            //Product
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<Product, CreateUpdateProductDto>();

            //Termin
            CreateMap<TerminDto, Termin>();
            CreateMap<Termin, TerminDto>();

            //Orders
            CreateMap<CreateUpdateOrderDto, OrderEntity>();
            CreateMap<OrderEntity, CreateUpdateOrderDto>()
                .ForMember(dest=>dest.Brand,opt=>opt.MapFrom(src=>src.Product.Brand));
        }
    }
}
