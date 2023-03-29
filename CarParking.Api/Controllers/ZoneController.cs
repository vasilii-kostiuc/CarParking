using AutoMapper;
using CarParking.Api.Models.Models;
using CarParking.Api.Wrappers;
using CarParking.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarParking.Models.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZoneController : ApiControllerBase
    {
        private readonly IZoneService _zoneService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;


        public ZoneController(IZoneService zoneService, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _zoneService = zoneService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        // GET: api/<ZonesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Zone> zones = await _zoneService.GetAllAsync();
                ApiResponse apiResponse = new ApiResponse(_mapper.Map<IEnumerable<ZoneDto>>(zones));
                return Ok(apiResponse);
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        // GET api/<ZonesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var zone = await _zoneService.GetAsync(id);
                ApiResponse apiResponse = new ApiResponse(_mapper.Map<ZoneDto>(zone));
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        // POST api/<ZonesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ZonesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ZonesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
