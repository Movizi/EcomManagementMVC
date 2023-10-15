using AutoMapper;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Products;
using EcomManagement.Models.Shippers;
using EcomManagement.Models.Suppliers;

namespace EcomManagement.Models
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // Category Map
            CreateMap<CategoryDto, Category>().ReverseMap();

            // Suppliers Map
            CreateMap<SupplierDto, Supplier>().ReverseMap().ForMember(dest => dest.Image, opt => opt.Ignore());

            // Shippers Map
            CreateMap<ShipperDto, Shipper>().ReverseMap().ForMember(dest => dest.Image, opt => opt.Ignore());

            // Products Map
            CreateMap<ProductDto, Product>().ReverseMap().ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
