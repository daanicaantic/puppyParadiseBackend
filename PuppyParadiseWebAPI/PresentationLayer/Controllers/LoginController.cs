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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var user = await _userService.GetByCredentialsAsync(request.Email, request.Password);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var token = _loginService.GenerateToken(user);
            return Ok(new LoginResponseDTO { Token = token });
        }
    }
}
