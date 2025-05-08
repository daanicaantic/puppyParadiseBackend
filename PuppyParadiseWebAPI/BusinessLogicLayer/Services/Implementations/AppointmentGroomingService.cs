using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Constants.ExceptionsConstants;
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

        public AppointmentGroomingService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAppointmentGroomingDTO> AddAppointmentGrooming(AddAppointmentGroomingDTO dto, int userId)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(dto.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            if (dog.DogSize == null)
                throw new Exception(DogExceptionsConstants.UnknownDogSize);

            var package = await _unitOfWork.GroomingPackages.GetById(dto.GroomingPackageId);
            if (package == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);

            double basePrice = package.Price;

            string size = dog.DogSize.Name.ToLower();
            switch (size)
            {
                case "small":
                    basePrice *= 0.8;
                    break;
                case "large":
                    basePrice *= 1.2;
                    break;
                case "medium":
                    // Nema promene u ceni za medium
                    break;
                default:
                    throw new Exception(DogExceptionsConstants.UnknownDogSize);
            }

            double extraServicesPrice = 0;
            var extraServices = new List<GroomingServiceAppointment>();

            if (dto.ExtraServiceIds != null && dto.ExtraServiceIds.Any())
            {
                var services = await _unitOfWork.GroomingServices
                    .GetAllGroomingServicesByIds(dto.ExtraServiceIds); 

                extraServicesPrice = services.Sum(s => s.Price);

                extraServices = services.Select(s => new GroomingServiceAppointment
                {
                    GroomingServiceId = s.Id
                }).ToList();
            }

            var appointment = new AppointmentGrooming
            {
                DogId = dto.DogId,
                UserId = userId,
                GroomingPackageId = dto.GroomingPackageId,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                ExtraServices = extraServices,
                Status = ConstStatus.Pending,
                TotalPrice = basePrice + extraServicesPrice
            };

            await _unitOfWork.GroomingAppointments.Add(appointment);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetAppointmentGroomingDTO>(appointment);
        }

        public async Task<GetAppointmentGroomingDTO> UpdateAppointmentStatus(int appointmentId, string newStatus)
        {
            var appointment = await _unitOfWork.GroomingAppointments.GetById(appointmentId);
            if (appointment == null)
                throw new Exception("Appointment not found.");

            if (newStatus != ConstStatus.Approved && newStatus != ConstStatus.Rejected)
                throw new Exception("Invalid status.");

            appointment.Status = newStatus;

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetAppointmentGroomingDTO>(appointment);
        }
    }
}

