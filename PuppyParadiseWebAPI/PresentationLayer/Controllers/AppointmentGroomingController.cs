using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Interfaces;
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

                var result = await _appointmentGroomingService.AddAppointmentGrooming(dto, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("status/{appointmentId}")]
        //[Authorize(Roles = "Admin")]  
        public async Task<IActionResult> UpdateAppointmentStatus(int appointmentId, [FromBody] string newStatus)
        {
            if (!StatusValidator.IsValid(newStatus))
                return BadRequest("Invalid status value. Allowed values are: Pending, Approved, or Rejected.");
            try
            {
                var updatedAppointment = await _appointmentGroomingService.UpdateAppointmentStatus(appointmentId, newStatus);
                return Ok(updatedAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
