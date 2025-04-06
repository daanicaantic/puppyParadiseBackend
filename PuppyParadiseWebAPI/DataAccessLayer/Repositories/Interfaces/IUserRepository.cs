using DomainLayer.DTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddUser(User user);

        Task<User> GetUser(int id);

        Task<User> GetByEmail(string email);

        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}
