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
    public class TrainingPackageRepository : Repository<TrainingPackage>, ITrainingPackageRepository
    {
        public TrainingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<double> GetPriceForTrainingPackage(int trainingPackageId)
        {
            var trainingPackage = await _puppyParadiseContext.TrainingPackages
                .FirstOrDefaultAsync(p => p.Id == trainingPackageId);

            return trainingPackage.Price;
        }
    }
}
