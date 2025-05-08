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

        Task<GetUserDTO> GetUserByEmail(string email);

        Task<GetUserDTO> GetUserByPhoneNumber(string phoneNumber);

        Task<PagedResult<GetUserDTO>> GetUsersPerPage(UserFilterDTO usersFilter);

        Task DeleteUser(int id);

        Task UpdateUserInfo(UpdateUserInfoDTO updateUserInfoDTO);

        Task UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO);
    }
}
