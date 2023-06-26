using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;

namespace CarParking.DataAccess.Repositories
{
    public class ParkingReposirory : Repository<Parking>, IParkingRepository
    {
        public ParkingReposirory(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
