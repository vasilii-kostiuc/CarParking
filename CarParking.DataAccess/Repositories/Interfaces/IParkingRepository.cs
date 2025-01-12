using CarParking.Models.Entities;

namespace CarParking.DataAccess.Repositories.Interfaces
{
    public interface IParkingRepository : IRepository<Parking>
    {
         Task<IEnumerable<Parking>> GetAllAsync(int userId);
         Task<IEnumerable<Parking>> GetActive(int userId);
         Task<IEnumerable<Parking>> GetHistory(int userId);
    }
}
