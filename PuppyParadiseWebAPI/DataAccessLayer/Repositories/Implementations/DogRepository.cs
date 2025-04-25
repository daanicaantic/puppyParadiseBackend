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
    public class DogRepository : Repository<Dog>, IDogRepository
    {
        public DogRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<List<Dog>> GetDogsByOwnerId(int ownerId)
        {
            return await _puppyParadiseContext.Dogs
                .Include(d => d.DogSize)
                .Include(d => d.Owner)
                .Where(d => d.OwnerId == ownerId)
                .ToListAsync();
        }
        public async Task<Dog> GetDogById(int dogId)
        {
            var dog = await _puppyParadiseContext.Dogs
                .Include(d => d.DogSize)  
                .Include(d => d.Owner)    
                .FirstOrDefaultAsync(d => d.Id == dogId);

            return dog;
        }

    }
}
