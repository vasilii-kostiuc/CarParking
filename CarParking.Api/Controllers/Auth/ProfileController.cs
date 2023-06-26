using AutoMapper;
using CarParking.Api.Models.Models.User;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace CarParking.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ApiControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            User user = await _userService.GetAsync(userId);
            var profileResponse = _mapper.Map<User, ProfileResponse>(user);
            
            return Ok(profileResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]ProfileUpdateRequest profileUpdateRequest)
        {
            var updateProfileDto = _mapper.Map<ProfileUpdateRequest, UpdateProfileDto>(profileUpdateRequest);
            int userId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _userService.UpdateProfile(userId, updateProfileDto);

            return Ok();
        }

    }
}
