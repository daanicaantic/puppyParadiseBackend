using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class SittingPackageRepository : Repository<SittingPackage>, ISittingPackageRepository
    {
        public SittingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<SittingPackage> GetSittingPackageByName(string name)
        {
            var sittingPackage = await _puppyParadiseContext.SittingPackages
                .FirstOrDefaultAsync(sp => sp.Name == name);
            return sittingPackage;
        }
    }
}
