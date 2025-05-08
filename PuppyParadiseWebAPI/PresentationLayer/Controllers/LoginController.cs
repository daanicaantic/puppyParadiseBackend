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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private readonly IUserService _userService;

        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginRequestDTO request)
        {
            try
            {
                var user = await _loginService.LogInAsync(request);
                if (user == null)
                    return Unauthorized("Invalid email or password.");

                var token = _loginService.GenerateToken(user);

                return Ok(new LoginResponseDTO { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
