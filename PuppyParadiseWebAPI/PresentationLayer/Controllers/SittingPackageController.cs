using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittingPackageController : ControllerBase
    {
        private readonly ISittingPackageService _sittingPackageService;

        public SittingPackageController(ISittingPackageService sittingPackageService)
        {
            _sittingPackageService = sittingPackageService;
        }

        [Route("AddSittingPackage")]
        [HttpPost]
        public async Task<IActionResult> AddSittingPackage([FromBody] SittingPackage sittingPackage)
        {
            try
            {
                await _sittingPackageService.AddSittingPackage(sittingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSittingPackage/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSittingPackage(int id)
        {
            try
            {
                var sp = await _sittingPackageService.GetSittingPackageById(id);
                return Ok(sp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllSittingPackages")]
        [HttpGet]
        public async Task<IActionResult> GetAllSittingPackages()
        {
            try
            {
                var spList = await _sittingPackageService.GetAllSittingPackages();
                return Ok(spList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateSittingPackage")]
        [HttpPost]
        public async Task<IActionResult> UpdateSittingPackage([FromBody] SittingPackage sittingPackage)
        {
            try
            {
                await _sittingPackageService.UpdateSittingPackage(sittingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteSittingPackage/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSittingPackage(int id)
        {
            try
            {
                await _sittingPackageService.DeleteSittingPackage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
