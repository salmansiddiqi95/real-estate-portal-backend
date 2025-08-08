using AutoMapper;
using RealEstate.API.Models;
using RealEstate.API.DTOs;

namespace RealEstate.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Property, PropertyDto>().ReverseMap();
        }
    }
}

