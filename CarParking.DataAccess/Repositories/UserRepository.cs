using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarParking.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool IsUniqueUser(string email)
        {
            var user = _dbSet.FirstOrDefault(x => x.Email == email);
            
            if (user == null)
            {
                return true;
            }

            return false;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email.ToLower() == x.Email.ToLower());
        }

    }

}
