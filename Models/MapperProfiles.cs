using AutoMapper;
using EcomManagement.Models.Categories;

namespace EcomManagement.Models
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // Category Map
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
