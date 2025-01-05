using AutoMapper;
using CarParking.Api.Models.Models.Parking;
using CarParking.Api.Models.Models.User;
using CarParking.Api.Models.Models.Vehicle;
using CarParking.Api.Models.Models.Zone;
using CarParking.Models;

using CarParking.Models.Entities;
using CarParking.Services.Models.Parking;
using CarParking.Services.Models.Vehicle;
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

            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleCreateRequest, VehicleCreateDto>();
            CreateMap<VehicleCreateDto, Vehicle>();
            CreateMap<VehicleUpdateRequest, VehicleUpdateDto>();

            CreateMap<Zone, ZoneDto>().ReverseMap();
            
            CreateMap<ParkingStartRequest, ParkingStartDto>();
            CreateMap<ParkingStartDto, Parking>();
            CreateMap<Parking, ParkingDto>();

        }
    }
}