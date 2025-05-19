using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAppointmentTrainingRepository : IRepository<AppointmentTraining>
    {
        Task<AppointmentTraining> GetTrainingAppointmentByIdAsync(int appointmentId);

        Task<List<AppointmentTraining>> GetByUserIdAsync(int userId);

        Task<List<AppointmentTraining>> GetByDogIdAsync(int dogId);

        Task<bool> HasOverlappingAppointmentAsync(int dogId, DateOnly startDate, DateOnly endDate, int? excludeAppointmentId);
    }
}
