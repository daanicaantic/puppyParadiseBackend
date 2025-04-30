using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.WalkingPackageDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class WalkingPackageRepository : Repository<WalkingPackage>, IWalkingPackageRepository
    {
        public WalkingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<List<WalkingPackageDTO>> GetAllWalkingPackage()
        {
            return await _puppyParadiseContext.WalkingPackages
                .Select(s => new WalkingPackageDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                }).ToListAsync();

        }
    }
}
