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
using DomainLayer.DTOs.AppointmentWalkingDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentWalkingService : IAppointmentWalkingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentWalkingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAppointmentWalking(AddAppointmentWalkingDTO dto, int userId)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(dto.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            if (dog.DogSize == null)
                throw new Exception(DogExceptionsConstants.UnknownDogSize);

            if (dog.OwnerId != userId)
                throw new Exception(DogExceptionsConstants.DogOwnershipMismatch);

            var package = await _unitOfWork.WalkingPackages.GetById(dto.WalkingPackageId);
            if (package == null)
                throw new Exception(WalkingPackageExceptionsConstants.WalkingPackageWithGivenIdNotFound);

            if (!AppointmentDateTimeValidator.IsValidAppointmentDate(dto.PickupDate, dto.PickupTime))
                throw new Exception(AppointmentErrors.CannotScheduleInPast);

            double totalPrice = PriceCalculator.CalculatePrice(package.Price, dog.DogSize.Name);

            var appointment = new AppointmentWalking
            {
                DogId = dto.DogId,
                UserId = userId,
                PickupDate = dto.PickupDate,
                PickupTime = dto.PickupTime,
                PickupAddress = dto.PickupAddress,
                ReturnAddress = dto.ReturnAddress,
                WalkingPackageId = dto.WalkingPackageId,
                TotalPrice = totalPrice,
                Status = ConstStatus.Pending,
                Note = dto.Note,
            };

            await _unitOfWork.WalkingAppointments.Add(appointment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAppointmentWalkingStatus(int appointmentId, string newStatus)
        {
            var appointment = await _unitOfWork.WalkingAppointments.GetById(appointmentId);
            if (appointment == null)
                throw new Exception(AppointmentWalkingExceptionsConstants.AppointmentWalkingWithGivenIdNotFound);

            appointment.Status = newStatus;
            _unitOfWork.WalkingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAppointmentWalking(UpdateAppointmentWalkingDTO dto, int userId)
        {
            var appointmentWalking = await _unitOfWork.WalkingAppointments.GetById(dto.Id);
            if (appointmentWalking == null)
                throw new Exception(AppointmentWalkingExceptionsConstants.AppointmentWalkingWithGivenIdNotFound);

            var dog = await _unitOfWork.Dogs.GetDogById(dto.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            if (dog.DogSize == null)
                throw new Exception(DogExceptionsConstants.UnknownDogSize);

            if (dog.OwnerId != userId)
                throw new Exception(DogExceptionsConstants.DogOwnershipMismatch);

            var package = await _unitOfWork.WalkingPackages.GetById(dto.WalkingPackageId);
            if (package == null)
                throw new Exception(WalkingPackageExceptionsConstants.WalkingPackageWithGivenIdNotFound);

            if (!AppointmentDateTimeValidator.IsValidAppointmentDate(dto.PickupDate, dto.PickupTime))
                throw new Exception(AppointmentErrors.CannotScheduleInPast);

            double totalPrice = PriceCalculator.CalculatePrice(package.Price, dog.DogSize.Name);

            appointmentWalking.DogId = dto.DogId;
            appointmentWalking.PickupDate = dto.PickupDate;
            appointmentWalking.PickupTime = dto.PickupTime;
            appointmentWalking.PickupAddress = dto.PickupAddress;
            appointmentWalking.ReturnAddress = dto.ReturnAddress;
            appointmentWalking.WalkingPackageId = dto.WalkingPackageId;
            appointmentWalking.TotalPrice = totalPrice;
            appointmentWalking.Status = ConstStatus.Pending;
            appointmentWalking.Note = dto.Note;

            _unitOfWork.WalkingAppointments.Update(appointmentWalking);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetAppointmentWalkingDTO> GetAppointmentWalkingById(int id)
        {
            var appointment = await _unitOfWork.WalkingAppointments.GetAppointmentWalkingById(id);

            if (appointment == null)
                throw new Exception(AppointmentWalkingExceptionsConstants.AppointmentWalkingWithGivenIdNotFound);

            return _mapper.Map<GetAppointmentWalkingDTO>(appointment);
        }

        public async Task<List<GetAppointmentWalkingDTO>> GetAllAppointmentWalkings()
        {
            var appointments = await _unitOfWork.WalkingAppointments.GetAllAppointmentWalkings();
            return _mapper.Map<List<GetAppointmentWalkingDTO>>(appointments);
        }

        public async Task DeleteAppointmentWalking(int appointmentId,int userId)
        {
            var appointmentWalking = await _unitOfWork.WalkingAppointments.GetAppointmentWalkingById(appointmentId);
            if (appointmentWalking == null)
                throw new Exception(AppointmentGroomingExceptionsConstants.AppointmentGroomingWithGivenIdNotFound);
            if (appointmentWalking.UserId != userId)
                throw new Exception(AppointmentWalkingExceptionsConstants.UnauthorizedToDeleteAppointment);

            _unitOfWork.WalkingAppointments.Delete(appointmentWalking);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
