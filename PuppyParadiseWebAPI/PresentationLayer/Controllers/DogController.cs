using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.DogDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        public async Task<IActionResult> AddDog([FromBody] AddDogDTO dogDTO)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return Unauthorized();
                int parsedUserId = int.Parse(userId);

                await _dogService.AddDog(dogDTO,parsedUserId);
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

        [Route("GetDogsByOwnerId")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDogsByOwnerId()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return Unauthorized();
                int parsedUserId = int.Parse(userId);

                var dogs = await _dogService.GetDogsByOwnerId(parsedUserId);
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("UpdateDog")]
        [HttpPut]
        public async Task<IActionResult> UpdateDog([FromBody] UpdateDogDTO dogUpdateDTO)
        {
            try
            {
                await _dogService.UpdateDog(dogUpdateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteDog/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDog(int id)
        {
            try
            {
                await _dogService.DeleteDog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
