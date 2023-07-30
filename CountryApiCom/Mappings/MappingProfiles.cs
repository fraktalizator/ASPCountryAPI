using AutoMapper;
using CityApiCom.Dto;
using CityApiCom.Models;

namespace CityApiCom.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Country, CountryDTO>()
                .ForMember(d => d.Region,
                    o => o.MapFrom(src => src.Region)
                ).ReverseMap();
            CreateMap<Region, RegionDTO>()
                .ForMember(p => p.Name,
                o => o.MapFrom(src => src.Name)
                ).ReverseMap();
        }
        
    }
}
