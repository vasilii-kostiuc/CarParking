using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarParking.DataAccess.Repositories
{
    public class ParkingReposirory : Repository<Parking>, IParkingRepository
    {
        public ParkingReposirory(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Parking>> GetActive(int userId)
        {
            return await this._dbSet.Where(p => p.UserId == userId).Where(p=>p.TotalPrice == 0).ToListAsync<Parking>();
        }

        public async Task<IEnumerable<Parking>> GetAllAsync(int userId)
        {
            return await this._dbSet.Where(p => p.UserId == userId).ToListAsync<Parking>();
        }

        public async  Task<IEnumerable<Parking>> GetHistory(int userId)
        {
            return await this._dbSet.Where(p => p.UserId == userId).Where(p => p.TotalPrice != 0).ToListAsync<Parking>();
        }
    }
}
