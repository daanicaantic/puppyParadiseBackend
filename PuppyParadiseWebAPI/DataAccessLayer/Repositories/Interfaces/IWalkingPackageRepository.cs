using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Implementations;
using DomainLayer.DTOs.WalkingPackageDTOs;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IWalkingPackageRepository : IRepository<WalkingPackage>
    {
        Task<List<GetWalkingPackageDTO>> GetAllWalkingPackage();
    }
}
