using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class GroomingServiceService : IGroomingServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroomingServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GroomingService> GetGroomingServiceById(int groomingServiceId)
        {
            var groomingService = await _unitOfWork.GroomingServices.GetById(groomingServiceId);
            if (groomingService == null)
                throw new Exception(GroomingServiceExceptionsConstants.GroomingServiceWithGivenIdNotFound);
            return groomingService;
        }

        public async Task AddGroomingService(GroomingServiceWithoutIdDTO groomingServiceWithoutIdDTO)
        {
            var groomingService = new GroomingService
            {
                Name = groomingServiceWithoutIdDTO.Name,
                Description = groomingServiceWithoutIdDTO.Description,
                Price = groomingServiceWithoutIdDTO.Price
            };

            await _unitOfWork.GroomingServices.Add(groomingService);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GroomingServiceDTO>> GetAllGroomingServices()
        {
            var services = await _unitOfWork.GroomingServices.GetAll();
            var dtoList = services.Select(s => new GroomingServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price
            }).ToList();
            return dtoList;
        }

        public async Task UpdateGroomingService(GroomingServiceDTO groomingServiceDTO)
        {
            var gsForEdit = await GetGroomingServiceById(groomingServiceDTO.Id);

            gsForEdit.Name = groomingServiceDTO.Name;
            gsForEdit.Description = groomingServiceDTO.Description;
            gsForEdit.Price = groomingServiceDTO.Price;

            _unitOfWork.GroomingServices.Update(gsForEdit);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteGroomingService(int groomingServiceId)
        {
            var groomingService = await GetGroomingServiceById(groomingServiceId);

            _unitOfWork.GroomingServices.Delete(groomingService);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
