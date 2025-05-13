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
        Task<GetUserDTO> GetUserById(int id);

        Task<GetUserDTO> GetUserByEmail(string email);

        Task<GetUserDTO> GetUserByPhoneNumber(string phoneNumber);

        Task DeleteUser(int id);

        Task<PagedResult<GetUserDTO>> GetUsersPerPage(UserFilterDTO usersFilter);

        Task UpdateUserInfo(UpdateUserInfoDTO updateUserInfoDTO);

        Task UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO);
    }
}
