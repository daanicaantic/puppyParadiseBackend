﻿using DomainLayer.DTOs.UserDTOs;
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
        Task<User> GetUser(int id);

        Task<UserDTO> GetByEmail(string email);

        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}
