using AutoMapper;
using CarParking.Api.Models.Models.Vehicle;
using CarParking.Api.Wrappers;
using CarParking.Models.Entities;
using CarParking.Services.Models.Vehicle;
using CarParking.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ApiControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllAsync();
                var response = new ApiResponse
                {
                    Data = _mapper.Map<IEnumerable<VehicleDto>>(vehicles)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }

        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetAsync(id);
                var response = new ApiResponse
                {
                    Data = _mapper.Map<VehicleDto>(vehicle)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleCreateRequest vehicleCreateRequest)
        {
            try
            {
                var vehicleDto = _mapper.Map<VehicleCreateDto>(vehicleCreateRequest);
                int vehicleId = await _vehicleService.CreateAsync(vehicleDto);

                var response = new ApiResponse()
                {
                    Data = new VehicleCreateResponse { Id = vehicleId }
                };

                return Ok(CreatedAtAction("Get", new { id = vehicleId }, response));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleUpdateRequest vehicleUpdateRequest)
        {
            try
            {
                if (vehicleUpdateRequest == null || id != vehicleUpdateRequest.Id)
                {
                    return BadRequest();
                }
                var vehicleDto = _mapper.Map<VehicleUpdateDto>(vehicleUpdateRequest);
                await _vehicleService.UpdateAsync(vehicleDto);

                var response = new ApiResponse()
                {
                    Data = new VehicleUpdateResponse { Id = id }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vehicleService.DeleteAsync(id);
                return Ok(new ApiResponse());
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
