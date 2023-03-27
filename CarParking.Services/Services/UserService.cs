using CarParking.DataAccess.Repositories;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services.Models.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> LoginAsync(UserLoginDto loginDto)
        {
            User user = await _repository.FindByEmailAsync(loginDto.Email);
            
            if(user == null)
            {
                throw new Exception($"User with this Email: {loginDto.Email} doesnt exists");
            }    

            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("Wrong Password");
            }

            return user;

        }

        public async Task<User> RegisterAsync(UserRegisterDto registrationDto)
        {
            if (_repository.IsUniqueUser(registrationDto.Email))
            {
                var user = new User()
                {
                    Email = registrationDto.Email,
                    Name = registrationDto.Name,
                    Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password),
                };

                return await _repository.AddAsync(user);
            }
            throw new Exception($"User with {registrationDto.Email} already exist");
        }
    }
}
