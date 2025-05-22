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
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;
using DomainLayer.Profiles.AppointmentSittingProfiles;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentSittingService : IAppointmentSittingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentSittingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAppointmentSittingDTO> CreateSittingAppointmentAsync(AddAppointmentSittingDTO appointment)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(appointment.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            var user = await _unitOfWork.Users.GetById(appointment.UserId);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            var (dropoff, pickup) = AppointmentSittingServiceHelpers.ValidateAndGetDateTimes(appointment.DropoffDate, appointment.DropoffTime, appointment.PickupDate, appointment.PickupTime);

            var appointmentTimeConflict = _mapper.Map<AppointmentSittingDTO>(appointment);

            bool hasConflict = await _unitOfWork.SittingAppointments.HasOverlappingAppointmentAsync(appointmentTimeConflict, null);
            if (hasConflict)
                throw new Exception(AppointmentSittingExceptionsConstants.DogHasOverlappingAppointment);

            var totalPrice = await CalculateTotalPriceAsync(dog, dropoff, pickup);

            var sittingAppointment = _mapper.Map<AppointmentSitting>(appointment);
            sittingAppointment.TotalPrice = totalPrice;
            sittingAppointment.Status = ConstStatus.Pending;

            await _unitOfWork.SittingAppointments.Add(sittingAppointment);
            await _unitOfWork.SaveChangesAsync();

            var sittingApp = _mapper.Map<GetAppointmentSittingDTO>(sittingAppointment);
            return sittingApp;
        }

        public async Task<AppointmentSitting> GetSittingAppointmentOrThrowAsync(int appointmentId)
        {
            var appointment = await _unitOfWork.SittingAppointments.GetSittingAppointmentByIdAsync(appointmentId);
            if (appointment == null)
                throw new KeyNotFoundException(AppointmentSittingExceptionsConstants.SittingAppointmentWithGivenIdNotFound);

            return appointment;
        }

        public async Task<GetAppointmentSittingDTO> GetByIdWithDetailsAsync(int appointmentId)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(appointmentId);

            var sittingAppointment = _mapper.Map<GetAppointmentSittingDTO>(appointment);
            return sittingAppointment;
        }

        public async Task<IEnumerable<GetAppointmentSittingDTO>> GetByUserIdAsync(int userId)
        {
            var saUser = await _unitOfWork.SittingAppointments.GetByUserIdAsync(userId);

            var sittingAppointmentUser = _mapper.Map<IEnumerable<GetAppointmentSittingDTO>>(saUser);
            return sittingAppointmentUser;
        }

        public async Task ApproveAppointmentAsync(int appointmentId)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(appointmentId);

            if (appointment.Status == ConstStatus.Approved)
                return;

            appointment.Status = ConstStatus.Approved;

            _unitOfWork.SittingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RejectAppointmentAsync(int appointmentId)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(appointmentId);

            if (appointment.Status == ConstStatus.Rejected)
                return;

            appointment.Status = ConstStatus.Rejected;

            _unitOfWork.SittingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetAppointmentSittingDTO> UpdateAppointmentAsync(UpdateAppointmentSittingDTO updateAppointmentDTO)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(updateAppointmentDTO.Id);

            var dog = await _unitOfWork.Dogs.GetDogById(appointment.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            var (dropoff, pickup) = AppointmentSittingServiceHelpers.ValidateAndGetDateTimes(updateAppointmentDTO.DropoffDate, updateAppointmentDTO.DropoffTime, updateAppointmentDTO.PickupDate, updateAppointmentDTO.PickupTime);

            var appointmentTimeConflict = _mapper.Map<AppointmentSittingDTO>(appointment);

            bool hasConflict = await _unitOfWork.SittingAppointments.HasOverlappingAppointmentAsync(appointmentTimeConflict, updateAppointmentDTO.Id);
            if (hasConflict)
                throw new Exception(AppointmentSittingExceptionsConstants.DogHasOverlappingAppointment);

            //_mapper.Map(updateAppointmentDTO, appointment);
            appointment.DropoffDate = updateAppointmentDTO.DropoffDate;
            appointment.DropoffTime = updateAppointmentDTO.DropoffTime;
            appointment.PickupDate = updateAppointmentDTO.PickupDate;
            appointment.PickupTime = updateAppointmentDTO.PickupTime;
            appointment.Note = updateAppointmentDTO.Note ?? string.Empty;

            appointment.TotalPrice = await CalculateTotalPriceAsync(dog, dropoff, pickup);
            appointment.Status = ConstStatus.Pending;

            _unitOfWork.SittingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();

            var sittingApp = _mapper.Map<GetAppointmentSittingDTO>(appointment);
            return sittingApp;
        }

        public async Task DeleteSittingAppointmentAsync(int appointmentId)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(appointmentId);

            _unitOfWork.SittingAppointments.Delete(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<double> CalculateTotalPriceAsync(Dog dog, DateTime dropoff, DateTime pickup)
        {
            var totalHours = (pickup - dropoff).TotalHours;
            var fullDays = (int)(totalHours / 24);
            var remainingHours = totalHours % 24;

            var hourlySitting = await _unitOfWork.SittingPackages.GetSittingPackageByName(ConstSittingPackages.HourlySitting);
            var dailySitting = await _unitOfWork.SittingPackages.GetSittingPackageByName(ConstSittingPackages.DailySitting);

            double basePrice = 0;
            if (fullDays == 0 && remainingHours <= 12)
            {
                basePrice = Math.Ceiling(remainingHours) * hourlySitting.Price;
            }
            else if (fullDays >= 0 && remainingHours <= 12)
            {
                basePrice = (fullDays * dailySitting.Price) + (Math.Ceiling(remainingHours) * hourlySitting.Price);
            }
            else if (fullDays >= 0 && remainingHours >= 12)
            {
                basePrice = (fullDays + 1) * dailySitting.Price;
            }

            return Math.Round(PriceCalculator.CalculatePrice(basePrice, dog.DogSize.Name), 2);
        }

        public async Task<PagedResult<GetAppointmentSittingDTO>> GetSittingAppointmentsAsync(AppointmentQueryParameters query, int currentUserId, bool isAdmin)
        {
            var pagedResult = await _unitOfWork.SittingAppointments.GetSittingAppointmentsAsync(query, currentUserId, isAdmin);
            return pagedResult;
        }
    }
}
