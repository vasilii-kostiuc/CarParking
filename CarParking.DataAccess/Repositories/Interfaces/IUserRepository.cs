using CarParking.Models.Entities;
using CarParking.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string email);
        Task<User> Register(UserRegistrationDto registrationDto);
        Task<User> Login(UserLoginDto loginDto);
    }
}
