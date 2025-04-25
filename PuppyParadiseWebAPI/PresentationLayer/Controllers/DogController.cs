using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.DogDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [Route("AddDog")]
        [HttpPost]
        public async Task<IActionResult> AddDog([FromBody] DogWithoutIdDTO dogDTO)
        {
            try
            {
                await _dogService.AddDog(dogDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetDog/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDog(int id)
        {
            try
            {
                var dogDTO = await _dogService.GetDogById(id);
                return Ok(dogDTO);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Route("GetDogsByOwnerId/{ownerId}")]
        [HttpGet]
        public async Task<IActionResult> GetDogsByOwnerId(int ownerId)
        {
            try
            {
                var dogs = await _dogService.GetDogsByOwnerId(ownerId);
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
