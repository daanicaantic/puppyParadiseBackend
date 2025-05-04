using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    internal class DogSizeRepository : Repository<DogSize>, IDogSizeRepository
    {
        public DogSizeRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<DogSize> GetDogSizeByWeight(double weight)
        {
            var dogSize = await _puppyParadiseContext.DogSizes
                .FirstOrDefaultAsync(ds => weight >= ds.MinWeight && weight <= ds.MaxWeight);

            return dogSize;
        }
    }
}
