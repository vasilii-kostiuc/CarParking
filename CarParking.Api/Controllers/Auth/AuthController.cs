using AutoMapper;
using CarParking.Api.Models.Models.User;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services.Models.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarParking.Api.Controllers.Auth
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IMapper mapper,IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest registrationRequest)
        {
            try {
                var userRegisterDto = _mapper.Map<RegistrationRequest, UserRegisterDto>(registrationRequest);
                var registeredUser = await _userService.RegisterAsync(userRegisterDto);
                //TODO implement token generation

                string token = CreateToken(registeredUser);

                return Ok(new RegisterResponse()
                {
                    AccessToken = token                    
                });

            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var userLoginDto = _mapper.Map<LoginRequest, UserLoginDto>(loginRequest);
                var user = await _userService.LoginAsync(userLoginDto);
                //TODO implement token generation

                string token = CreateToken(user);

                return Ok(new LoginResponse()
                {
                    AccessToken = token
                });
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Autodriver")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
