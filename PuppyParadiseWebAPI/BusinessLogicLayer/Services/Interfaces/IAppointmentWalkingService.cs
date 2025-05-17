using BusinessLogicLayer.Constants.ExceptionsConstants;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.DTOs.AppointmentWalkingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAppointmentWalkingService
    {
        Task AddAppointmentWalking(AddAppointmentWalkingDTO dto, int userId);

        public Task UpdateAppointmentWalkingStatus(int appointmentId, string newStatus);

        public Task UpdateAppointmentWalking(UpdateAppointmentWalkingDTO dto, int userId);

        public Task<GetAppointmentWalkingDTO> GetAppointmentWalkingById(int id);

        Task<List<GetAppointmentWalkingDTO>> GetAllAppointmentWalkings();

        public Task DeleteAppointmentWalking(int appointmentId,int userId);

    }
}
