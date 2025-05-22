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
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentTrainingService : IAppointmentTrainingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentTrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAppointmentTrainingDTO> CreateTrainingAppointmentAsync(AddAppointmentTrainingDTO appointment)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(appointment.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            var user = await _unitOfWork.Users.GetById(appointment.UserId);
            if (user == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            var package = await _unitOfWork.TrainingPackages.GetById(appointment.TrainingPackageId);
            if (package == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageWithGivenIdNotFound);

            var trainingAppointment = _mapper.Map<AppointmentTraining>(appointment);

            var packageDuration = package.DurationInWeeks;
            trainingAppointment.EndDate = trainingAppointment.StartDate.AddDays(packageDuration * 7 - 1);

            bool hasConflict = await _unitOfWork.TrainingAppointments.HasOverlappingAppointmentAsync(dog.Id, appointment.StartDate, trainingAppointment.EndDate, null);
            if(hasConflict)
                throw new Exception(AppointmentTrainingExceptionsConstants.DogHasOverlappingAppointment);

            trainingAppointment.TotalPrice = await _unitOfWork.TrainingPackages.GetPriceForTrainingPackage(trainingAppointment.TrainingPackageId);
            trainingAppointment.Status = ConstStatus.Pending;

            await _unitOfWork.TrainingAppointments.Add(trainingAppointment);
            await _unitOfWork.SaveChangesAsync();

            var trainingApp = _mapper.Map<GetAppointmentTrainingDTO>(trainingAppointment);
            return trainingApp;
        }

        public async Task<AppointmentTraining> GetTrainingAppointmentOrThrowAsync(int appointmentId)
        {
            var appointment = await _unitOfWork.TrainingAppointments.GetTrainingAppointmentByIdAsync(appointmentId);
            if (appointment == null)
                throw new KeyNotFoundException(AppointmentSittingExceptionsConstants.SittingAppointmentWithGivenIdNotFound);

            return appointment;
        }

        public async Task<GetAppointmentTrainingDTO> GetByIdWithDetailsAsync(int appointmentId)
        {
            var appointment = await GetTrainingAppointmentOrThrowAsync(appointmentId);

            var trainingAppointment = _mapper.Map<GetAppointmentTrainingDTO>(appointment);
            return trainingAppointment;
        }

        public async Task<List<GetAppointmentTrainingDTO>> GetByUserIdAsync(int userId)
        {
            var taUser = await _unitOfWork.TrainingAppointments.GetByUserIdAsync(userId);

            var trainingAppointmentUser = _mapper.Map<List<GetAppointmentTrainingDTO>>(taUser);
            return trainingAppointmentUser;
        }

        public async Task<List<GetAppointmentTrainingDTO>> GetByDogIdAsync(int dogId)
        {
            var taDog = await _unitOfWork.TrainingAppointments.GetByDogIdAsync(dogId);

            var trainingAppointmentDog = _mapper.Map<List<GetAppointmentTrainingDTO>>(taDog);
            return trainingAppointmentDog;
        }

        public async Task ApproveAppointmentAsync(int appointmentId)
        {
            var appointment = await GetTrainingAppointmentOrThrowAsync(appointmentId);

            if (appointment.Status == ConstStatus.Approved)
                return;

            appointment.Status = ConstStatus.Approved;

            _unitOfWork.TrainingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RejectAppointmentAsync(int appointmentId)
        {
            var appointment = await GetTrainingAppointmentOrThrowAsync(appointmentId);

            if (appointment.Status == ConstStatus.Rejected)
                return;

            appointment.Status = ConstStatus.Rejected;

            _unitOfWork.TrainingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetAppointmentTrainingDTO> UpdateAppointmentAsync(UpdateAppointmentTrainingDTO updateAppointmentDTO)
        {
            var appointment = await GetTrainingAppointmentOrThrowAsync(updateAppointmentDTO.Id);

            var dog = await _unitOfWork.Dogs.GetDogById(appointment.DogId);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            var package = await _unitOfWork.TrainingPackages.GetById(updateAppointmentDTO.TrainingPackageId);
            if (package == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageWithGivenIdNotFound);

            //_mapper.Map(updateAppointmentDTO, appointment);
            appointment.StartDate = updateAppointmentDTO.StartDate;
            appointment.TrainingPackageId = updateAppointmentDTO.TrainingPackageId;
            appointment.Note = updateAppointmentDTO.Note ?? string.Empty;

            var packageDuration = package.DurationInWeeks;
            appointment.EndDate = appointment.StartDate.AddDays(packageDuration * 7 - 1);

            bool hasConflict = await _unitOfWork.TrainingAppointments.HasOverlappingAppointmentAsync(dog.Id, updateAppointmentDTO.StartDate, appointment.EndDate, updateAppointmentDTO.Id);
            if(hasConflict)
                throw new Exception(AppointmentTrainingExceptionsConstants.DogHasOverlappingAppointment);

            appointment.TotalPrice = await _unitOfWork.TrainingPackages.GetPriceForTrainingPackage(appointment.TrainingPackageId);
            appointment.Status = ConstStatus.Pending;

            _unitOfWork.TrainingAppointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();

            var updatedAppointment = await _unitOfWork.TrainingAppointments.GetTrainingAppointmentByIdAsync(appointment.Id);
            var trainingApp = _mapper.Map<GetAppointmentTrainingDTO>(updatedAppointment);
            return trainingApp;
        }

        public async Task DeleteTrainingAppointmentAsync(int appointmentId)
        {
            var appointment = await GetTrainingAppointmentOrThrowAsync(appointmentId);

            _unitOfWork.TrainingAppointments.Delete(appointment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
