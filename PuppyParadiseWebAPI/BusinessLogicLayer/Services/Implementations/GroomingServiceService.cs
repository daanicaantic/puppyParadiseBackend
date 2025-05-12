using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GroomingServiceService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<GroomingService> GetGroomingServiceById(int groomingServiceId)
        {
            var groomingService = await _unitOfWork.GroomingServices.GetById(groomingServiceId);
            if (groomingService == null)
                throw new Exception(GroomingServiceExceptionsConstants.GroomingServiceWithGivenIdNotFound);
            return groomingService;
        }

        public async Task AddGroomingService(AddGroomingServiceDTO groomingServiceWithoutIdDTO)
        {
            var groomingService = _mapper.Map<GroomingService>(groomingServiceWithoutIdDTO);

            await _unitOfWork.GroomingServices.Add(groomingService);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetGroomingServiceDTO>> GetAllGroomingServices()
        {
            return await _unitOfWork.GroomingServices.GetAllGroomingServices();
        }

        public async Task<List<GroomingService>> GetAllGroomingServicesByIds(List<int> ids)
        {
            return await _unitOfWork.GroomingServices.GetAllGroomingServicesByIds(ids);
        }


        public async Task UpdateGroomingService(GetGroomingServiceDTO groomingServiceDTO)
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

        public async Task<(double price, List<GroomingServiceAppointment> services)> CalculateExtraServices(List<int> ids)
        {
            if (ids == null || !ids.Any())
                return (0, new List<GroomingServiceAppointment>());

            var services = await _unitOfWork.GroomingServices.GetAllGroomingServicesByIds(ids);

            var foundIds = services.Select(s => s.Id).ToHashSet();
            var missingIds = ids.Where(id => !foundIds.Contains(id)).ToList();

            if (missingIds.Any())
                throw new Exception(string.Format(GroomingServiceExceptionsConstants.MissingGroomingService, string.Join(",", missingIds)));

            var price = services.Sum(s => s.Price);

            var appointments = services.Select(s => new GroomingServiceAppointment
            {
                GroomingServiceId = s.Id
            }).ToList();

            return (price, appointments);
        }
    }
}
