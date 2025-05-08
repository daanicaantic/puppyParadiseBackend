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
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task AddUser(AddUserDTO userDTO)
        {
            var role = await _unitOfWork.Roles.GetById(userDTO.RoleId);
            if (role == null)
                throw new Exception("Role not found!");

            var email = await _unitOfWork.Users.GetUserByEmail(userDTO.Email);
            if (email != null)
                throw new Exception(UserExceptionsConstants.UserWithGivenEmailAlreadyExists);

            var number = await _unitOfWork.Users.GetUserByPhoneNumber(userDTO.PhoneNumber);
            if (number != null)
                throw new Exception(UserExceptionsConstants.UserWithGivenPhoneNumberAlreadyExists);

            /*var user = new User
             {
                 Name = userDTO.Name,
                 Surname = userDTO.Surname,
                 Email = userDTO.Email,
                 PhoneNumber = userDTO.PhoneNumber,
                 RoleId = userDTO.RoleId,
             };*/
            var user = _mapper.Map<User>(userDTO);
            user.Password = _passwordHasher.HashPassword(user, userDTO.Password);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetUserDTO> GetUserById(int id)
        {
            var user = await _unitOfWork.Users.GetUserById(id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            //var u = new GetUserDTO(user.Name, user.Surname, user.Email, user.PhoneNumber, user.RoleId, user.RoleName);
            var u = _mapper.Map<GetUserDTO>(user);
            return u;
        }

        public async Task<GetUserDTO> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(email);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenEmailNotFound);

            var u = _mapper.Map<GetUserDTO>(user);
            return u;
        }

        public async Task<GetUserDTO> GetUserByPhoneNumber(string phoneNumber)
        {
            var user = await _unitOfWork.Users.GetUserByPhoneNumber(phoneNumber);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenPhoneNumberNotFound);

            var u = _mapper.Map<GetUserDTO>(user);
            return u;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResult<GetUserDTO>> GetUsersPerPage(UserFilterDTO usersFilter)
        {
            var pagedResult = await _unitOfWork.Users.GetUsersPerPageAsync(usersFilter);

            return pagedResult;
        }

        public async Task UpdateUserInfo(UpdateUserInfoDTO updateUserInfoDTO)
        {
            var user = await _unitOfWork.Users.GetById(updateUserInfoDTO.Id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            user.Name = updateUserInfoDTO.Name;
            user.Surname = updateUserInfoDTO.Surname;
            user.Email = updateUserInfoDTO.Email;
            user.PhoneNumber = updateUserInfoDTO.PhoneNumber;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            var user = await _unitOfWork.Users.GetById(updateUserPasswordDTO.Id);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            if (!string.IsNullOrEmpty(updateUserPasswordDTO.NewPassword) || !string.IsNullOrEmpty(updateUserPasswordDTO.ConfirmPassword))
            {
                if (updateUserPasswordDTO.NewPassword != updateUserPasswordDTO.ConfirmPassword)
                    throw new ArgumentException("New password and confirm password do not match.");

                user.Password = _passwordHasher.HashPassword(user, updateUserPasswordDTO.NewPassword);
            }

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
