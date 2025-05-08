using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Constants;
using DomainLayer.DTOs.GroomingPackageDTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroomingPackageController : ControllerBase
    {
        private readonly IGroomingPackageService _groomingPackageService;

        public GroomingPackageController(IGroomingPackageService groomingPackageService)
        {
            _groomingPackageService = groomingPackageService;
        }

        [Route("AddGroomingPackage")]
        [HttpPost]
        public async Task<IActionResult> AddGroomingPackage([FromBody] GroomingPackage groomingPackage)
        {
            try
            {
                await _groomingPackageService.AddGroomingPackage(groomingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetGroomingPackage/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetGroomingPackage(int id)
        {
            try
            {
                var gp = await _groomingPackageService.GetGroomingPackageById(id);
                return Ok(gp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = ConstRoles.Admin)]
        [Route("GetAllGroomingPackages")]
        [HttpGet]
        public async Task<IActionResult> GetAllGroomingPackages()
        {
            try
            {
                var gpList = await _groomingPackageService.GetAllGroomingPackages();
                return Ok(gpList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateGroomingPackage")]
        [HttpPut]
        public async Task<IActionResult> UpdateGroomingPackage([FromBody] GroomingPackage groomingPackage)
        {
            try
            {
                await _groomingPackageService.UpdateGroomingPackage(groomingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteGroomingPackage/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGroomingPackage(int id)
        {
            try
            {
                await _groomingPackageService.DeleteGroomingPackage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
