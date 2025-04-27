using BusinessLogicLayer.Services.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPackageController : ControllerBase
    {
        private readonly ITrainingPackageService _trainingPackageService;

        public TrainingPackageController(ITrainingPackageService trainingPackageService)
        {
            _trainingPackageService = trainingPackageService;
        }

        [Route("AddTrainingPackage")]
        [HttpPost]
        public async Task<IActionResult> AddTrainingPackage([FromBody] TrainingPackage trainingPackage)
        {
            try
            {
                await _trainingPackageService.AddTrainingPackage(trainingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTrainingPackage/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTrainingPackage(int id)
        {
            try
            {
                var tp = await _trainingPackageService.GetTrainingPackageById(id);
                return Ok(tp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllTrainingPackages")]
        [HttpGet]
        public async Task<IActionResult> GetAllTrainingPackages()
        {
            try
            {
                var tpList = await _trainingPackageService.GetAllTrainingPackages();
                return Ok(tpList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateTrainingPackage")]
        [HttpPut]
        public async Task<IActionResult> UpdateTrainingPackage([FromBody] TrainingPackage trainingPackage)
        {
            try
            {
                await _trainingPackageService.UpdateTrainingPackage(trainingPackage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteTrainingPackage/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrainingPackage(int id)
        {
            try
            {
                await _trainingPackageService.DeleteTrainingPackage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
