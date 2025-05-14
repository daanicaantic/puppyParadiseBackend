using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IGroomingServiceRepository : IRepository<GroomingService>
    {

        Task<List<GetGroomingServiceDTO>> GetAllGroomingServices();

        Task<List<GroomingService>> GetAllGroomingServicesByIds(List<int> ids);
    }
}
