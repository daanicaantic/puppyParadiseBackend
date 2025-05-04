using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDogRepository : IRepository<Dog>
    {
        Task<List<Dog>> GetDogsByOwnerId(int ownerId);

        Task<Dog> GetDogById(int dogId);
    }
}
