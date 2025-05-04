﻿using System;
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

        public async Task AddGroomingService(GroomingServiceWithoutIdDTO groomingServiceWithoutIdDTO)
        {
            var groomingService = _mapper.Map<GroomingService>(groomingServiceWithoutIdDTO);

            await _unitOfWork.GroomingServices.Add(groomingService);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GroomingServiceDTO>> GetAllGroomingServices()
        {
            return await _unitOfWork.GroomingServices.GetAllGroomingServices();
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
