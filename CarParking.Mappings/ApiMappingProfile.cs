using AutoMapper;
using CarParking.Api.Models;
using CarParking.Api.Models.Models;
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
            CreateMap<ProfileUpdateRequest, UpdateProfileDto>().ReverseMap();
            CreateMap<User, ProfileResponse>();
        }
    }
}