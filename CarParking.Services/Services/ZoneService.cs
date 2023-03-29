using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository _zoneRepository;

        public ZoneService(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public async Task<IEnumerable<Zone>> GetAllAsync()
        {
            return await _zoneRepository.GetAllAsync();
        }

        public async Task<Zone> GetAsync(int zoneId)
        {
            return await _zoneRepository.FindAsync(zoneId);
        }
    }
}
