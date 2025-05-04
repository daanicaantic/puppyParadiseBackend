using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDogSizeRepository : IRepository<DogSize>
    {
        Task<DogSize> GetDogSizeByWeight(double weight);
    }
}
