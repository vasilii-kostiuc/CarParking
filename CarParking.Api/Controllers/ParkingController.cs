using AutoMapper;
using CarParking.Api.Models.Models.Parking;
using CarParking.Api.Wrappers;
using CarParking.Models.Entities;
using CarParking.Services.Models.Parking;
using CarParking.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParkingController : ApiControllerBase
    {
        private readonly IParkingService _parkingService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public ParkingController(IParkingService parkingService, IMapper mapper, IHttpContextAccessor contextAccessor = null)
        {
            _parkingService = parkingService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var parkings = await _parkingService.GetAllAsync();
                var response = new ApiResponse
                {
                    Data = _mapper.Map<IEnumerable <ParkingDto>>(parkings)
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var parking = await _parkingService.GetAsync(id);
                var response = new ApiResponse
                {
                    Data = _mapper.Map<ParkingDto>(parking)
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> Start([FromBody] ParkingStartRequest startRequest)
        {
            try
            {
                var startDto = _mapper.Map<ParkingStartDto>(startRequest);
                Parking parking = await _parkingService.StartAsync(startDto);
                ParkingDto parkingDto = _mapper.Map<ParkingDto>(parking);
                return Ok(new ApiResponse(parkingDto));
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPut]
        [Route("stop/{id}")]
        public async Task<IActionResult> Stop(int id)
        {
            try
            {
                Parking parking = await _parkingService.StopAsync(id);
                ParkingDto parkingDto = _mapper.Map<ParkingDto>(parking);
                var response = new ApiResponse(parkingDto);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
