using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO user)
        {
            try
            {
                await _userService.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetUserByEmail/{email}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmail(email);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetUserByPhoneNumber/{phoneNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)
        {
            try
            {
                var user = await _userService.GetUserByPhoneNumber(phoneNumber);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetUsersPerPage")]
        [HttpGet]
        public async Task<IActionResult> GetUsersPerPage([FromQuery] UserFilterDTO usersFilter)
        {
            try
            {
                var result = await _userService.GetUsersPerPage(usersFilter);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateUserInfo")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInfoDTO updateUserInfoDTO)
        {
            try
            {
                await _userService.UpdateUserInfo(updateUserInfoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateUserPassword")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            try
            {
                await _userService.UpdateUserPassword(updateUserPasswordDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
