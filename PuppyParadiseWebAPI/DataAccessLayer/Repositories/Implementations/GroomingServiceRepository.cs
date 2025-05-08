using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class GroomingServiceRepository : Repository<GroomingService>, IGroomingServiceRepository
    {
        public GroomingServiceRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<List<GroomingServiceDTO>> GetAllGroomingServices()
        {
            return await _puppyParadiseContext.GroomingServices
                .Select(s => new GroomingServiceDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                }).ToListAsync();
        }

        public async Task<List<GroomingService>> GetAllGroomingServicesByIds(List<int> ids)
        {
            return await _puppyParadiseContext.GroomingServices
                                 .Where(gs => ids.Contains(gs.Id))
                                 .ToListAsync();
        }
    }
}
