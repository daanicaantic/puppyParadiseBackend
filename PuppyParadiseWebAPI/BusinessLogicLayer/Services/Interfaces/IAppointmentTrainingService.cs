using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAppointmentTrainingService
    {
        Task<GetAppointmentTrainingDTO> CreateTrainingAppointmentAsync(AddAppointmentTrainingDTO appointment);

        Task<AppointmentTraining> GetTrainingAppointmentOrThrowAsync(int appointmentId);

        Task<GetAppointmentTrainingDTO> GetByIdWithDetailsAsync(int appointmentId);

        Task<List<GetAppointmentTrainingDTO>> GetByUserIdAsync(int userId);

        Task<List<GetAppointmentTrainingDTO>> GetByDogIdAsync(int dogId);

        Task ApproveAppointmentAsync(int appointmentId);

        Task RejectAppointmentAsync(int appointmentId);

        Task<GetAppointmentTrainingDTO> UpdateAppointmentAsync(UpdateAppointmentTrainingDTO updateAppointmentDTO);

        Task DeleteTrainingAppointmentAsync(int appointmentId);
    }
}
