using AutoMapper;
using Domain;
using WebAPI.Dtos;

namespace WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Classification, ClassificationDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<UserSys, UserSysDto>().ReverseMap();
            CreateMap<Filter, FilterDto>().ReverseMap();
            CreateMap<UserSys, UserLoginDto>().ReverseMap();
        }
    }
}