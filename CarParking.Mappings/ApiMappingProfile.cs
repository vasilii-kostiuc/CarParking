using AutoMapper;
using CarParking.Api.Models;
using CarParking.Models;

using CarParking.Models.Entities;
using CarParking.Services.Services.Models.User;

namespace CarParking.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<RegistrationRequest, UserRegisterDto>().ReverseMap(); 
            CreateMap<LoginRequest, UserLoginDto>().ReverseMap();
        }
    }
}