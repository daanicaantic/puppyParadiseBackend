using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.DTOs.WalkingPackageDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkingPackageController : ControllerBase
    {
        private readonly IWalkingPackageService _walkingPackageService;

        public WalkingPackageController(IWalkingPackageService walkingPackageService)
        {
            _walkingPackageService = walkingPackageService;
        }

        [Route("AddWalkingPackage")]
        [HttpPost]
        public async Task<IActionResult> AddWalkingPackage([FromBody] WalkingPackageWithoutIdDTO walkingPackageWithoutIdDTO)
        {
            try
            {
                await _walkingPackageService.AddWalkingPackage(walkingPackageWithoutIdDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetWalkingPackage/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetWalkingPackage(int id)
        {
            try
            {
                var wp = await _walkingPackageService.GetWalkingPackageById(id);
                return Ok(wp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllWalkingPackages")]
        [HttpGet]
        public async Task<IActionResult> GetAllWalkingPackages()
        {
            try
            {
                var wpList = await _walkingPackageService.GetAllWalkingPackages();
                return Ok(wpList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateWalkingPackage")]
        [HttpPut]
        public async Task<IActionResult> UpdateGroomingService([FromBody] WalkingPackageDTO walkingPackageDTO)
        {
            try
            {
                await _walkingPackageService.UpdateWalkingPackage(walkingPackageDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteWalkingPackage/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalkingPackage(int id)
        {
            try
            {
                await _walkingPackageService.DeleteWalkingPackage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
