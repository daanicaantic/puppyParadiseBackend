using BusinessLogicLayer.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Helpers;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginRequestDTO request)
        {
            try
            {
                if (!RegexHelper.IsValidEmail(request.Email))
                    throw new Exception(UserExceptionsConstants.InvalidEmailFormat);

                var loginResponse = await _authService.LogInAsync(request);
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            try
            {
                if (!RegexHelper.IsValidEmail(request.Email))
                    throw new Exception(UserExceptionsConstants.InvalidEmailFormat);

                if (!RegexHelper.IsValidPassword(request.Password))
                    throw new Exception(UserExceptionsConstants.InvalidPasswordFormat);

                if (request.Password != request.ConfirmPassword)
                    throw new Exception(UserExceptionsConstants.PasswordsDoNotMatch);

                var registerResponse = await _authService.RegisterAsync(request);
                return Ok(registerResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
