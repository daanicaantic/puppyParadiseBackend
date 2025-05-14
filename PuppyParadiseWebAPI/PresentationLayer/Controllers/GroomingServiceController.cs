using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroomingServiceController : ControllerBase
    {
        private readonly IGroomingServiceService _groomingServiceService;

        public GroomingServiceController(IGroomingServiceService groomingServiceService)
        {
            _groomingServiceService = groomingServiceService;
        }

        [Route("AddGroomingService")]
        [HttpPost]
        public async Task<IActionResult> AddGroomingService([FromBody] AddGroomingServiceDTO groomingServiceWithoutIdDTO)
        {
            try
            {
                await _groomingServiceService.AddGroomingService(groomingServiceWithoutIdDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetGroomingService/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetGroomingService(int id)
        {
            try
            {
                var gs = await _groomingServiceService.GetGroomingServiceById(id);
                return Ok(gs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllGroomingServices")]
        [HttpGet]
        public async Task<IActionResult> GetAllGroomingServices()
        {
            try
            {
                var gsList = await _groomingServiceService.GetAllGroomingServices();
                return Ok(gsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateGroomingService")]
        [HttpPut]
        public async Task<IActionResult> UpdateGroomingService([FromBody] GetGroomingServiceDTO groomingServiceDTO)
        {
            try
            {
                await _groomingServiceService.UpdateGroomingService(groomingServiceDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteGroomingService/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGroomingService(int id)
        {
            try
            {
                await _groomingServiceService.DeleteGroomingService(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
