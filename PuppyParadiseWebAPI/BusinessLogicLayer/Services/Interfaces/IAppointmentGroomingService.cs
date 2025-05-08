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
        Task<GetAppointmentGroomingDTO> AddAppointmentGrooming(AddAppointmentGroomingDTO dto, int userId);

        Task<GetAppointmentGroomingDTO> UpdateAppointmentStatus(int appointmentId, string newStatus);
    }
}
