using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);

        Task<LoginResponseDTO> LogInAsync(LoginRequestDTO loginRequest);

        Task<LoginResponseDTO> RegisterAsync(RegisterRequestDTO user);
    }
}
