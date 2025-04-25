using AutoMapper;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Constants;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO userDTO)
        {
            var role = await _unitOfWork.Roles.GetById(userDTO.RoleId);
            if (role == null)
                throw new Exception("Role not found!");

            /*var user = new User
             {
                 Name = userDTO.Name,
                 Surname = userDTO.Surname,
                 Email = userDTO.Email,
                 PhoneNumber = userDTO.PhoneNumber,
                 RoleId = userDTO.RoleId,
             };*/
            var user = _mapper.Map<User>(userDTO);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _unitOfWork.Users.GetUser(id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            //var u = new UserDTO(user.Name, user.Surname, user.Email, user.PhoneNumber, user.RoleId, user.Role.Name);
            var us = _mapper.Map<UserDTO>(user);

            return us;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.Users.GetByEmail(email);
            if (user == null)
                throw new Exception("User with this email doesn't exist.");
            return user;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var user = await _unitOfWork.Users.GetByPhoneNumber(phoneNumber);
            if (user == null)
                throw new Exception("User with this phone number doesn't exist.");
            return user;
        }

        public async Task<User?> GetByCredentialsAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByCredentialsAsync(email, password);
            if (user == null)
                throw new Exception("User with this email and password doesn't exist.");
            return user;
        }

        public async Task<PagedResult<UserDTO>> GetUsersPerPage(UserFilterDTO filter)
        {
            var users = await _unitOfWork.Users.GetUsersPerPageAsync(
                filter.Name, filter.PhoneNumber, filter.RoleId, filter.Page, filter.PageSize);

            var totalCount = await _unitOfWork.Users.GetUsersCountAsync(
                filter.Name, filter.PhoneNumber, filter.RoleId);

            return new PagedResult<UserDTO>
            {
                Items = _mapper.Map<List<UserDTO>>(users),
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

    }
}
