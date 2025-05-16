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
using DomainLayer.DTOs.UserDTOs;
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
            var dog = await _unitOfWork.Dogs.GetById(appointment.DogId);
            if (dog == null)
                throw new Exception($"Dog with ID {appointment.DogId} not found"); //DogWithGivenIdNotFound

            var user = await _unitOfWork.Users.GetById(appointment.UserId);
            if (user == null)
                throw new Exception($"User with ID {appointment.UserId} not found"); //UserWithGivenIdNotFound

            var dropoff = appointment.DropoffDate.ToDateTime(appointment.DropoffTime);
            var pickup = appointment.PickupDate.ToDateTime(appointment.PickupTime);

            if (pickup <= dropoff)
                throw new Exception("Pickup time must be after dropoff time.");

            var appointmentTimeConflict = new AppointmentTimeRangeDTO
            {
                DogId = appointment.DogId,
                DropoffDate = appointment.DropoffDate,
                DropoffTime = appointment.DropoffTime,
                PickupDate = appointment.PickupDate,
                PickupTime = appointment.PickupTime
            };

            bool hasConflict = await _unitOfWork.SittingAppointments.HasOverlappingAppointmentAsync(appointmentTimeConflict);
            if (hasConflict)
                throw new Exception("The selected dog already has another sitting appointment during the requested time.");

            var priceDTO = new AppointmentSittingDTO
            {
                DogId = appointment.DogId,
                DropoffDate = appointment.DropoffDate,
                DropoffTime = appointment.DropoffTime,
                PickupDate = appointment.PickupDate,
                PickupTime = appointment.PickupTime
            };

            var totalPrice = await CalculateTotalPriceAsync(priceDTO);

            var sittingAppointment = new AppointmentSitting
            {
                DogId = appointment.DogId,
                UserId = appointment.UserId,
                DropoffDate = appointment.DropoffDate,
                DropoffTime = appointment.DropoffTime,
                PickupDate = appointment.PickupDate,
                PickupTime = appointment.PickupTime,
                Note = appointment.Note ?? string.Empty,
                TotalPrice = totalPrice,
                Status = ConstStatus.Pending
            };

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

        public async Task<GetAppointmentSittingDTO> UpdateAppointmentAsync(UpdateAppointmentSittingDTO appointmentDTO)
        {
            var appointment = await GetSittingAppointmentOrThrowAsync(appointmentDTO.Id);

            appointment.DropoffDate = appointmentDTO.DropoffDate;
            appointment.DropoffTime = appointmentDTO.DropoffTime;
            appointment.PickupDate = appointmentDTO.PickupDate;
            appointment.PickupTime = appointmentDTO.PickupTime;
            appointment.Note = appointmentDTO.Note ?? string.Empty;

            var dropoff = appointment.DropoffDate.ToDateTime(appointment.DropoffTime);
            var pickup = appointment.PickupDate.ToDateTime(appointment.PickupTime);

            if (pickup <= dropoff)
                throw new Exception("Pickup time must be after dropoff time.");

            var appointmentTimeConflict = new AppointmentTimeRangeDTO
            {
                DogId = appointment.DogId,
                DropoffDate = appointmentDTO.DropoffDate,
                DropoffTime = appointmentDTO.DropoffTime,
                PickupDate = appointmentDTO.PickupDate,
                PickupTime = appointmentDTO.PickupTime,
                ExcludeAppointmentId = appointmentDTO.Id
            };

            bool hasConflict = await _unitOfWork.SittingAppointments.HasOverlappingAppointmentAsync(appointmentTimeConflict);
            if (hasConflict)
                throw new Exception("The selected dog already has another sitting appointment during the requested time.");

            var priceDTO = new AppointmentSittingDTO
            {
                DogId = appointment.DogId,
                DropoffDate = appointmentDTO.DropoffDate,
                DropoffTime = appointmentDTO.DropoffTime,
                PickupDate = appointmentDTO.PickupDate,
                PickupTime = appointmentDTO.PickupTime
            };

            appointment.TotalPrice = await CalculateTotalPriceAsync(priceDTO);
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

        public async Task<double> CalculateTotalPriceAsync(AppointmentSittingDTO appointment)
        {
            var dropoff = appointment.DropoffDate.ToDateTime(appointment.DropoffTime);
            var pickup = appointment.PickupDate.ToDateTime(appointment.PickupTime);

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

            var dog = await _unitOfWork.Dogs.GetDogById(appointment.DogId);
            return Math.Round(PriceCalculator.CalculatePrice(basePrice, dog.DogSize.Name), 2);
        }
    }
}
