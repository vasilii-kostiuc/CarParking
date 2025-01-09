using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity, bool persist = true);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<T> entities, bool persist = true);
        Task UpdateAsync(T entity, bool persist = true);
        Task UpdateRangeAsync(IEnumerable<T> entity, bool persist = true);
        Task DeleteAsync(int id, bool persist = true);
        Task DeleteAsync(T entity, bool persist = true);
        Task DeleteRangeAsync(IEnumerable<T> entities, bool persist = true);
        Task SaveChangesAsync();
    }
}
