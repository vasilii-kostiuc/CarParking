using CarParking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services.Interfaces
{
    public interface IZoneService
    {
        Task<Zone> GetAsync(int zoneId);
        Task<IEnumerable<Zone>> GetAllAsync();
    }
}
