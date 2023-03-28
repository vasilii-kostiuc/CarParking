using AutoMapper;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using CarParking.Services.Models.Vehicle;
using CarParking.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(VehicleCreateDto vehicleCreateDto)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleCreateDto);
            await _repository.AddAsync(vehicle);
            return vehicle.Id;
        }

        public async Task DeleteAsync(int vehicleId)
        {
            await _repository.DeleteAsync(vehicleId);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vehicle> GetAsync(int vehicleId)
        {
            return await _repository.FindAsync(vehicleId);            
        }

        public async Task UpdateAsync(VehicleUpdateDto vehicleUpdateDto)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleUpdateDto);
            await _repository.UpdateAsync(vehicle);
        }
    }
}
