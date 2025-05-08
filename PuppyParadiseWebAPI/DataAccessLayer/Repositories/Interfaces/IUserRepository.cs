using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Helpers;
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
        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByPhoneNumber(string phoneNumber);

        Task<PagedResult<GetUserDTO>> GetUsersPerPageAsync(UserFilterDTO usersFilter);
    }
}
