﻿using DomainLayer.DTOs;
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

    }
}
