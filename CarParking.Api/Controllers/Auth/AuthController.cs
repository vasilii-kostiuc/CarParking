using AutoMapper;
using CarParking.Api.Models;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParking.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest registrationRequest)
        {
            try {
                var userRegisterDto = _mapper.Map<RegistrationRequest, UserRegisterDto>(registrationRequest);
                var registeredUser = await _userService.RegisterAsync(userRegisterDto);
                //TODO implement token generation
            }catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


    }
}
