using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class SittingPackageRepository : Repository<SittingPackage>, ISittingPackageRepository
    {
        public SittingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }
    }
}
