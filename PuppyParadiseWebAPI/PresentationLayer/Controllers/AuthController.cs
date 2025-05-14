using BusinessLogicLayer.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using BusinessLogicLayer.Services.Interfaces;

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
