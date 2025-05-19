using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAppointmentSittingService
    {
        Task<GetAppointmentSittingDTO> CreateSittingAppointmentAsync(AddAppointmentSittingDTO appointment);

        Task<AppointmentSitting> GetSittingAppointmentOrThrowAsync(int appointmentId);

        Task<GetAppointmentSittingDTO> GetByIdWithDetailsAsync(int appointmentId);

        Task<IEnumerable<GetAppointmentSittingDTO>> GetByUserIdAsync(int userId);

        Task<List<GetAppointmentSittingDTO>> GetByDogIdAsync(int dogId);

        Task ApproveAppointmentAsync(int appointmentId);

        Task RejectAppointmentAsync(int appointmentId);

        Task<GetAppointmentSittingDTO> UpdateAppointmentAsync(UpdateAppointmentSittingDTO updateSittingAppointmentDTO);

        Task DeleteSittingAppointmentAsync(int appointmentId);
    }
}
