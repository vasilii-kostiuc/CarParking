using CarParking.Models.Entities;
using CarParking.Services.Models.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services.Interfaces
{
    public interface IParkingService
    {
        public Task<Parking> StartAsync(ParkingStartDto parkingStart);

        public Task<Parking> StopAsync(int id);
        
        public Task<Parking> GetAsync(int parkingId);

        public Task<IEnumerable<Parking>> GetAllAsync();
       
        public Task<IEnumerable<Parking>> GetAllAsync(int userId);
        
        public Task<IEnumerable<Parking>> getActive(int userId);
        
        public Task<IEnumerable<Parking>> getHistory(int userId);
    }
}