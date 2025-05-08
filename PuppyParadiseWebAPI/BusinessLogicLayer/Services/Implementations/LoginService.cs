using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginService(IConfiguration config, IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            _config = config;
            _unitOfWork = unitOfWork;
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

        public async Task<User?> LogInAsync(LoginRequestDTO loginRequest)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(loginRequest.Email);

            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenEmailNotFound);

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

            if (result != PasswordVerificationResult.Success)
                throw new Exception(UserExceptionsConstants.UsersPasswordIsNotCorrect);

            return user;
        }
    }
}
