using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Constants;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Extensions;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentGroomingController : ControllerBase
    {
        private readonly IAppointmentGroomingService _appointmentGroomingService;

        public AppointmentGroomingController(IAppointmentGroomingService appointmentGroomingService)
        {
            _appointmentGroomingService = appointmentGroomingService;
        }

        [Route("AddAppointmentGrooming")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAppointmentGrooming([FromBody] AddAppointmentGroomingDTO dto)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentGroomingService.AddAppointmentGrooming(dto, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateAppointmentGrooming/status/{appointmentId}")]
        [HttpPut]
        [Authorize(Roles = ConstRoles.Admin)]  
        public async Task<IActionResult> UpdateAppointmentStatus(int appointmentId, [FromBody] string newStatus)
        {
            if (!StatusValidator.IsValid(newStatus))
                return BadRequest(StatusExceptionsConstants.InvalidStatus);
            try
            {
                await _appointmentGroomingService.UpdateAppointmentGroomingStatus(appointmentId, newStatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateAppointmentGrooming")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAppointmentGrooming([FromBody] UpdateAppointmentGroomingDTO dto)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentGroomingService.UpdateAppointmentGrooming(dto,userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateDateTimeAppointmentGrooming/{appointmentId}/{date}/{time}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDateTimeAppointmentStatus(int appointmentId, DateOnly date, TimeOnly time)
        {
            try
            {
                await _appointmentGroomingService.UpdateAppointmentGroomingDateTime(appointmentId, date,time);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAppointmentGroomingById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAppointmentGroomingById(int id)
        {
            try
            {
                var appointmentGrooming = await _appointmentGroomingService.GetAppointmentGroomingById(id);
                return Ok(appointmentGrooming);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllAppointmentGroomings")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentGroomings()
        {
            try
            {
                var result = await _appointmentGroomingService.GetAllAppointmentGroomings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [Route("DeleteAppointmentGrooming/{appointmentId}")]
        [HttpDelete]
        [Authorize] 
        public async Task<ActionResult> DeleteAppointmentGrooming(int appointmentId)
        {
            try
            {
                int userId = User.GetRequiredUserId();

                await _appointmentGroomingService.DeleteAppointmentGrooming(appointmentId,userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
