using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Repositories
{
    public class ZoneRepository :Repository<Zone>, IZoneRepository
    {
        public ZoneRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
