using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTrainingController : ControllerBase
    {
        private readonly IAppointmentTrainingService _appointmentTrainingService;

        public AppointmentTrainingController(IAppointmentTrainingService appointmentTrainingService)
        {
            _appointmentTrainingService = appointmentTrainingService;
        }

        [Route("CreateTrainingAppointment")]
        [HttpPost]
        public async Task<IActionResult> CreateTrainingAppointment([FromBody] AddAppointmentTrainingDTO appointmentTrainingDTO)
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                if (appointmentTrainingDTO.StartDate < today)
                    throw new Exception(AppointmentErrors.CannotScheduleInPast);

                var ta = await _appointmentTrainingService.CreateTrainingAppointmentAsync(appointmentTrainingDTO);
                return Ok(ta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTrainingAppointment/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTrainingAppointment(int id)
        {
            try
            {
                var appointmentTraining = await _appointmentTrainingService.GetByIdWithDetailsAsync(id);
                return Ok(appointmentTraining);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTrainingAppointmentByUserId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTrainingAppointmentByUserId(int id)
        {
            try
            {
                var taUser = await _appointmentTrainingService.GetByUserIdAsync(id);
                return Ok(taUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTrainingAppointmentByDogId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTrainingAppointmentByDogId(int id)
        {
            try
            {
                var taDog = await _appointmentTrainingService.GetByDogIdAsync(id);
                return Ok(taDog);
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
                await _appointmentTrainingService.ApproveAppointmentAsync(id);
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
                await _appointmentTrainingService.RejectAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateTrainingAppointment")]
        [HttpPut]
        public async Task<IActionResult> UpdateTrainingAppointment([FromBody] UpdateAppointmentTrainingDTO updateAppointmentTrainingDTO)
        {
            try
            {
                await _appointmentTrainingService.UpdateAppointmentAsync(updateAppointmentTrainingDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteTrainingAppointment/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrainingAppointment(int id)
        {
            try
            {
                await _appointmentTrainingService.DeleteTrainingAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
