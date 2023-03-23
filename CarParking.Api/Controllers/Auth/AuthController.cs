using AutoMapper;
using CarParking.Api.Models.Dto;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Dto;
using CarParking.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParking.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody]RegistrationRequestDto registrationRequestDto)
        {
            if (registrationRequestDto != null)
            {
                UserRegistrationDto userRegistrationDto = _mapper.Map<RegistrationRequestDto, UserRegistrationDto>(registrationRequestDto);
                if (_userRepository.IsUniqueUser(userRegistrationDto.Email))
                {
                    await _userRepository.Register(userRegistrationDto);

                }
            }
            return BadRequest();
        }



    }
}
