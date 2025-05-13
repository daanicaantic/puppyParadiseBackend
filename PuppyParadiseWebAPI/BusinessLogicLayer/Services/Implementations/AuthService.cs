using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IConfiguration config, IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponseDTO> LogInAsync(LoginRequestDTO loginRequest)
        {
            if (!RegexHelper.IsValidEmail(loginRequest.Email))
                throw new Exception(UserExceptionsConstants.InvalidEmailFormat);

            var user = await _unitOfWork.Users.GetUserByEmail(loginRequest.Email);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenEmailNotFound);

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);
            if (result != PasswordVerificationResult.Success)
                throw new Exception(UserExceptionsConstants.UsersPasswordIsNotCorrect);

            var token = GenerateToken(user);

            var loginResponse = new LoginResponseDTO();

            loginResponse.UserId = user.Id;
            loginResponse.Role = user.Role?.Name ?? "User";
            loginResponse.Token = token;

            return loginResponse;
        }

        public async Task<LoginResponseDTO> RegisterAsync(RegisterRequestDTO registerRequest)
        {
            if (!RegexHelper.IsValidEmail(registerRequest.Email))
                throw new Exception(UserExceptionsConstants.InvalidEmailFormat);

            var existingUser = await _unitOfWork.Users.GetUserByEmail(registerRequest.Email);
            if (existingUser != null)
                throw new Exception(UserExceptionsConstants.UserWithGivenEmailAlreadyExists);

            if (!RegexHelper.IsValidPassword(registerRequest.Password))
                throw new Exception(UserExceptionsConstants.InvalidPasswordFormat);

            if (registerRequest.Password != registerRequest.ConfirmPassword)
                throw new Exception(UserExceptionsConstants.PasswordsDoNotMatch);

            var role = await _unitOfWork.Roles.GetById(registerRequest.RoleId);
            if (role == null)
                throw new Exception(UserExceptionsConstants.RoleNotFound);

            var number = await _unitOfWork.Users.GetUserByPhoneNumber(registerRequest.PhoneNumber);
            if (number != null)
                throw new Exception(UserExceptionsConstants.UserWithGivenPhoneNumberAlreadyExists);

            var user = _mapper.Map<User>(registerRequest);
            user.Password = _passwordHasher.HashPassword(user, registerRequest.Password);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();

            var token = GenerateToken(user);

            var loginResponse = new LoginResponseDTO();

            loginResponse.UserId = user.Id;
            loginResponse.Role = user.Role?.Name ?? "User";
            loginResponse.Token = token;

            return loginResponse;
        }
    }
}
