using CarParking.Models.Entities;
using CarParking.Services.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> GetAsync(int vehicleId);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<int> CreateAsync(VehicleCreateDto vehicle);
        Task UpdateAsync(VehicleUpdateDto vehicle);
        Task DeleteAsync(int vehicleId);
    }
}
