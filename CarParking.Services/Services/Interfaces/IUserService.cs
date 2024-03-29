﻿using CarParking.Models.Entities;
using CarParking.Services.Services.Models;
using CarParking.Services.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserRegisterDto registrationDto);
        Task<User> LoginAsync(UserLoginDto loginDto);
        Task<User> GetAsync(int userId);
        Task<User> GetByEmailUserAsync(string email);
        Task UpdateProfile(int userId, UpdateProfileDto profileDto);
        Task UpdatePassword(int userId, string password, string confirmation);
    }
}
