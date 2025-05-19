using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSittingController : ControllerBase
    {
        private readonly IAppointmentSittingService _appointmentSittingService;

        public AppointmentSittingController(IAppointmentSittingService appointmentSittingService)
        {
            _appointmentSittingService = appointmentSittingService;
        }

        [Route("CreateSittingAppointment")]
        [HttpPost]
        public async Task<IActionResult> CreateSittingAppointment([FromBody] AddAppointmentSittingDTO appointmentSittingDTO)
        {
            try
            {
                var sa = await _appointmentSittingService.CreateSittingAppointmentAsync(appointmentSittingDTO);
                return Ok(sa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSittingAppointment/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSittingAppointment(int id)
        {
            try
            {
                var appointmentSitting = await _appointmentSittingService.GetByIdWithDetailsAsync(id);
                return Ok(appointmentSitting);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSittingAppointmentByUserId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSittingAppointmentByUserId(int id)
        {
            try
            {
                var saUser = await _appointmentSittingService.GetByUserIdAsync(id);
                return Ok(saUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("ApproveAppointment/{id}")]
        [HttpPut]
        public async Task<IActionResult> ApproveAppointment(int id)
        {
            try
            {
                await _appointmentSittingService.ApproveAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("RejectAppointment/{id}")]
        [HttpPut]
        public async Task<IActionResult> RejectAppointment(int id)
        {
            try
            {
                await _appointmentSittingService.RejectAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateAppointment")]
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentSittingDTO updateAppointmentSittingDTO)
        {
            try
            {
                await _appointmentSittingService.UpdateAppointmentAsync(updateAppointmentSittingDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteSittingAppointment/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSittingAppointment(int id)
        {
            try
            {
                await _appointmentSittingService.DeleteSittingAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
