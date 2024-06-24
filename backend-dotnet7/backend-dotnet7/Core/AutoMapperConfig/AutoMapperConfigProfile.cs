using AutoMapper;
using backend_dotnet7.Core.Dtos.Corrosion;
using backend_dotnet7.Core.Dtos.HeatTreatment;
using backend_dotnet7.Core.Dtos.Materials;

using backend_dotnet7.Core.Dtos.Orders;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Product_Order;
using backend_dotnet7.Core.Dtos.Project;
using backend_dotnet7.Core.Dtos.ProjectTask;
using backend_dotnet7.Core.Dtos.Supplier;

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

            //Material
            CreateMap<MaterialDto, Material>();
            CreateMap<Material, MaterialDto>();

            //Supplier
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Supplier, SupplierDto>();

            //Project
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();

            //ProjectTask
            CreateMap<ProjectTask, ProjectTaskDto>();
            CreateMap<ProjectTaskDto, ProjectTask>();

            //HeatTreatment
            CreateMap<HeatTreatment, HeatTreatmentDto>();
            CreateMap<HeatTreatmentDto, HeatTreatment>();

            //Corrosion
            CreateMap<Corrosion, CorrosionDto>();
            CreateMap<CorrosionDto, Corrosion>();

            

      


        }
    }
}
