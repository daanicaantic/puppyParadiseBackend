using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Constants;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.DTOs.AppointmentWalkingDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentWalkingController : ControllerBase
    {
        private readonly IAppointmentWalkingService _appointmentWalkingService;

        public AppointmentWalkingController(IAppointmentWalkingService appointmentWalkingService)
        {
            _appointmentWalkingService = appointmentWalkingService;
        }

        [Route("AddAppointmentWalking")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAppointmentGrooming([FromBody] AddAppointmentWalkingDTO dto)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentWalkingService.AddAppointmentWalking(dto, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("UpdateAppointmentWalking/status/{appointmentId}")]
        [HttpPut]
        [Authorize(Roles = ConstRoles.Admin)]  
        public async Task<IActionResult> UpdateAppointmentWalking(int appointmentId, [FromBody] string newStatus)
        {
            if (!StatusValidator.IsValid(newStatus))
                return BadRequest(StatusExceptionsConstants.InvalidStatus);
            try
            {
                await _appointmentWalkingService.UpdateAppointmentWalkingStatus(appointmentId, newStatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateAppointmentWalking")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAppointmentWalking([FromBody] UpdateAppointmentWalkingDTO dto)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentWalkingService.UpdateAppointmentWalking(dto, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetAppointmentWalkingById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAppointmentWalkingById(int id)
        {
            try
            {
                var appointmentWalking = await _appointmentWalkingService.GetAppointmentWalkingById(id);
                return Ok(appointmentWalking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllAppointmentWalkings")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentWalkings()
        {
            try
            {
                var result = await _appointmentWalkingService.GetAllAppointmentWalkings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteAppointmentWalking/{appointmentId}")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteAppointmentWalking(int appointmentId)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentWalkingService.DeleteAppointmentWalking(appointmentId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
