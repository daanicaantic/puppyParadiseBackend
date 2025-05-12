using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Constants;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        //[Authorize]
        public async Task<IActionResult> AddAppointmentGrooming([FromBody] AddAppointmentGroomingDTO dto)
        {
            try
            {
                /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return Unauthorized();

                int parsedUserId = int.Parse(userId);*/

                var userId = 1;

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
        //[Authorize(Roles = "Admin")]  
        public async Task<IActionResult> UpdateAppointmentStatus(int appointmentId, [FromBody] string newStatus)
        {
            if (!StatusValidator.IsValid(newStatus))
                return BadRequest("Invalid status value. Allowed values are: Pending, Approved, or Rejected.");
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
        public async Task<IActionResult> UpdateAppointmentStatus([FromBody] UpdateAppointmentGroomingDTO dto)
        {
            /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 if (userId == null)
                     return Unauthorized();

                 int parsedUserId = int.Parse(userId);*/
            int userId = 1;
            try
            {
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
        //[Authorize(Roles = ConstRoles.Admin)] 
        public async Task<ActionResult> DeleteAppointmentGrooming(int appointmentId)
        {
            try
            {
                await _appointmentGroomingService.DeleteAppointmentGrooming(appointmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
