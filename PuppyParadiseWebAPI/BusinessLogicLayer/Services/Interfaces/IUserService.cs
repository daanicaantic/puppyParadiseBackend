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
        Task AddUser(AddUserDTO user);

        Task<GetUserDTO> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByPhoneNumber(string phoneNumber);

        Task<User?> GetUserByCredentialsAsync(string email, string password);

        Task<PagedResult<UserDTO>> GetUsersPerPage(UserFilterDTO usersFilter);

        Task DeleteUser(int id);
    }
}
