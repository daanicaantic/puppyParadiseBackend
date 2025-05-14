using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGroomingServiceService
    {
        Task<GroomingService> GetGroomingServiceById(int groomingServiceId);

        Task AddGroomingService(AddGroomingServiceDTO groomingServiceWithoutIdDTO);

        Task<List<GetGroomingServiceDTO>> GetAllGroomingServices();

        Task<List<GroomingService>> GetAllGroomingServicesByIds(List<int> ids);

        Task UpdateGroomingService(GetGroomingServiceDTO groomingServiceDTO);

        Task DeleteGroomingService(int groomingServiceId);

        Task<(double price, List<GroomingServiceAppointment> services)> CalculateExtraServices(List<int> ids);
    }
}
