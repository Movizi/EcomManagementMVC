using AutoMapper;
using EcomManagement.Models.Categories;
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
          

        }
    }
}
