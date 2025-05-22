using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAppointmentSittingService
    {
        Task<GetAppointmentSittingDTO> CreateSittingAppointmentAsync(AddAppointmentSittingDTO appointment);

        Task<AppointmentSitting> GetSittingAppointmentOrThrowAsync(int appointmentId);

        Task<GetAppointmentSittingDTO> GetByIdWithDetailsAsync(int appointmentId);

        Task<IEnumerable<GetAppointmentSittingDTO>> GetByUserIdAsync(int userId);

        Task ApproveAppointmentAsync(int appointmentId);

        Task RejectAppointmentAsync(int appointmentId);

        Task<GetAppointmentSittingDTO> UpdateAppointmentAsync(UpdateAppointmentSittingDTO updateSittingAppointmentDTO);

        Task DeleteSittingAppointmentAsync(int appointmentId);

        Task<PagedResult<GetAppointmentSittingDTO>> GetSittingAppointmentsAsync(AppointmentQueryParameters query, int currentUserId, bool isAdmin);
    }
}
