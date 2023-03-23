using Azure.Core;
using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Dto;
using CarParking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public Task<User> Login(UserLoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterAsync(UserRegistrationDto registrationDto)
        {
            var user = new User();
            user.Email = registrationDto.Email;
            user.Name = registrationDto.Name;
            user.Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
            await _dbSet.AddAsync(user);
            await SaveChangesAsync();


        }
    }

}
