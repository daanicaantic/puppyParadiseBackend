using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.GroomingPackageDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class GroomingPackageRepository : Repository<GroomingPackage>, IGroomingPackageRepository
    {
        public GroomingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {

        }

        public void UpdateGroomingPackage(GroomingPackage gpOld, GroomingPackage gpNew)
        {
            gpOld.Name = gpNew.Name;
            gpOld.Price = gpNew.Price;
            gpOld.Description = gpNew.Description;
        }
    }
}
