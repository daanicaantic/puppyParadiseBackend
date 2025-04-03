using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<User> GetUserById(int id); 
    }
}
