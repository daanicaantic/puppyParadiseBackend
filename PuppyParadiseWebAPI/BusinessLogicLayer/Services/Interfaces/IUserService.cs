using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Helpers;
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
        Task AddUser(UserDTO user);

        Task<UserDTO> GetUserById(int id);

        Task DeleteUser(int id);

        Task<UserDTO> GetUserByEmail (string email);

        Task<User> GetUserByPhoneNumber(string phoneNumber);

        Task<User?> GetByCredentialsAsync(string email, string password);

        Task<PagedResult<UserDTO>> GetUsersPerPage(UserFilterDTO filter);
    }
}
