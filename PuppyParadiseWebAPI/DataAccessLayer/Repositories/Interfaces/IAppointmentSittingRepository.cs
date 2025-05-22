using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAppointmentSittingRepository : IRepository<AppointmentSitting>
    {
        Task<AppointmentSitting> GetSittingAppointmentByIdAsync(int appointmentId);

        Task<IEnumerable<AppointmentSitting>> GetByUserIdAsync(int userId);

        Task<List<AppointmentSitting>> GetByDogIdAsync(int dogId);

        Task<bool> HasOverlappingAppointmentAsync(AppointmentSittingDTO appointment, int? excludeAppointmentId);

        Task<PagedResult<GetAppointmentSittingDTO>> GetSittingAppointmentsAsync(AppointmentQueryParameters query, int currentUserId, bool isAdmin);
    }
}
