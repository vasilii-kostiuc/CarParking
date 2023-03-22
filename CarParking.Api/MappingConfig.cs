using AutoMapper;
using CarParking.Api.Models.Dto;
using CarParking.Models.Dto;

namespace CarParking.Api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RegistrationRequestDto,UserRegistrationDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
