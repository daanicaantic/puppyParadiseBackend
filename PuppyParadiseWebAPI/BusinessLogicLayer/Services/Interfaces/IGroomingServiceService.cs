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

        Task AddGroomingService(GroomingServiceWithoutIdDTO groomingServiceWithoutIdDTO);

        Task<List<GroomingServiceDTO>> GetAllGroomingServices();

        Task<List<GroomingService>> GetAllGroomingServicesByIds(List<int> ids);

        Task UpdateGroomingService(GroomingServiceDTO groomingServiceDTO);

        Task DeleteGroomingService(int groomingServiceId);
    }
}
