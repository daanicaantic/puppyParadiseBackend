using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Constants;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentGroomingService : IAppointmentGroomingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IGroomingServiceService _groomingServiceService;

        public AppointmentGroomingService(IUnitOfWork unitOfWork,IMapper mapper, 
            IGroomingServiceService groomingServiceService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _groomingServiceService = groomingServiceService;
        }

        public async Task AddAppointmentGrooming(AddAppointmentGroomingDTO dto, int userId)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(dto.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            if (dog.DogSize == null)
                throw new Exception(DogExceptionsConstants.UnknownDogSize);

            if (dog.OwnerId != userId)
                throw new Exception(DogExceptionsConstants.DogOwnershipMismatch);

            var package = await _unitOfWork.GroomingPackages.GetById(dto.GroomingPackageId);
            if (package == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);

            double packagePrice = PriceCalculator.CalculatePrice(package.Price,dog.DogSize.Name);

            var (extraServicesPrice, extraServices) = await _groomingServiceService.CalculateExtraServices(dto.ExtraServiceIds);

            var appointment = new AppointmentGrooming
            {
                DogId = dto.DogId,
                UserId = userId,
                GroomingPackageId = dto.GroomingPackageId,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                ExtraServices = extraServices,
                Status = ConstStatus.Pending,
                TotalPrice = packagePrice + extraServicesPrice
            };

            await _unitOfWork.GroomingAppointments.Add(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAppointmentGroomingStatus(int appointmentId, string newStatus)
        {
            var appointment = await _unitOfWork.GroomingAppointments.GetAppointmentGroomingById(appointmentId);
            if(appointment==null)
                  throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);

            appointment.Status = newStatus;
            _unitOfWork.GroomingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAppointmentGroomingDateTime(int appointmentId, DateOnly date, TimeOnly time)
        {
            var appointment = await _unitOfWork.GroomingAppointments.GetAppointmentGroomingById(appointmentId);

            if (appointment == null)
                throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);

            appointment.AppointmentDate = date;

            appointment.AppointmentTime = time;
            _unitOfWork.GroomingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<GetAppointmentGroomingDTO> GetAppointmentGroomingById(int id)
        {
            var appointment = await _unitOfWork.GroomingAppointments.GetAppointmentGroomingById(id);

            if (appointment == null)
                throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);

            return _mapper.Map<GetAppointmentGroomingDTO>(appointment);
        }

        public async Task<List<GetAppointmentGroomingDTO>> GetAllAppointmentGroomings()
        {
            var appointments = await _unitOfWork.GroomingAppointments.GetAllAppointmentGroomings();
            return _mapper.Map<List<GetAppointmentGroomingDTO>>(appointments);
        }

        public async Task DeleteAppointmentGrooming(int appointmentId,int userId)
        {
            var appointmentGrooming = await _unitOfWork.GroomingAppointments.GetAppointmentGroomingById(appointmentId);
            if (appointmentGrooming == null)
                throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);
            if (appointmentGrooming.UserId != userId)
                throw new Exception(AppointmentGroomingExceptionsConstants.UnauthorizedToDeleteAppointment);

            _unitOfWork.GroomingAppointments.Delete(appointmentGrooming);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAppointmentGrooming(UpdateAppointmentGroomingDTO dto,int userId)
        {
            var appointmentGrooming = await _unitOfWork.GroomingAppointments.GetAppointmentGroomingById(dto.Id);
            if (appointmentGrooming == null)
                throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);

            var dog = await _unitOfWork.Dogs.GetDogById(dto.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            if (dog.DogSize == null)
                throw new Exception(DogExceptionsConstants.UnknownDogSize);

            if (dog.OwnerId != userId)
                throw new Exception(DogExceptionsConstants.DogOwnershipMismatch);

            var package = await _unitOfWork.GroomingPackages.GetById(dto.GroomingPackageId);
            if (package == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);

            double packagePrice = PriceCalculator.CalculatePrice(package.Price, dog.DogSize.Name);

            var (extraServicesPrice, extraServices) = await _groomingServiceService.CalculateExtraServices(dto.ExtraServiceIds);

            appointmentGrooming.DogId = dto.DogId;
            appointmentGrooming.AppointmentDate = dto.AppointmentDate;
            appointmentGrooming.AppointmentTime = dto.AppointmentTime;
            appointmentGrooming.GroomingPackageId = dto.GroomingPackageId;

            appointmentGrooming.ExtraServices = appointmentGrooming.ExtraServices ?? new List<GroomingServiceAppointment>();
            
            appointmentGrooming.ExtraServices.Clear();
            appointmentGrooming.ExtraServices.AddRange(extraServices);
            

            appointmentGrooming.TotalPrice = packagePrice + extraServicesPrice;

            appointmentGrooming.Status = ConstStatus.Pending;

            _unitOfWork.GroomingAppointments.Update(appointmentGrooming);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}


