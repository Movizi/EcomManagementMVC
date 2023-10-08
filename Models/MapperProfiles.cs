using AutoMapper;
using EcomManagement.Models.Categories;
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
        }
    }
}
