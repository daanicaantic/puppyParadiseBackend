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
        Task<GetUserDTO> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByPhoneNumber(string phoneNumber);

        Task<User?> GetUserByCredentialsAsync(string email, string password);

        Task<PagedResult<UserDTO>> GetUsersPerPageAsync(UserFilterDTO usersFilter);
    }
}
