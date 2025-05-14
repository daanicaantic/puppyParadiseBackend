using DomainLayer.DTOs.AppointmentGroomingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAppointmentGroomingService
    {
        Task AddAppointmentGrooming(AddAppointmentGroomingDTO dto, int userId);

        Task UpdateAppointmentGroomingStatus(int appointmentId, string newStatus);

        Task UpdateAppointmentGroomingDateTime(int appointmentId, DateOnly date,TimeOnly time);

        Task UpdateAppointmentGrooming(UpdateAppointmentGroomingDTO dto,int userId);

        Task<GetAppointmentGroomingDTO> GetAppointmentGroomingById(int id);

        Task<List<GetAppointmentGroomingDTO>> GetAllAppointmentGroomings();

        Task DeleteAppointmentGrooming(int appointmentId);
    }
}
