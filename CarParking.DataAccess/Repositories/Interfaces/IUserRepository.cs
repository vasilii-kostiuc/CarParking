using CarParking.Models.Entities;
using CarParking.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        bool IsUniqueUser(string email);
        Task<User> FindByEmailAsync(string email);
    }
}
