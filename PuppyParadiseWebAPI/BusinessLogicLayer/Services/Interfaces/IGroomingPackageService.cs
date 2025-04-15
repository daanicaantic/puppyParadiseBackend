using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOs.GroomingPackageDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGroomingPackageService
    {
        Task<GroomingPackage> GetGroomingPackageById(int groomingPackageId);

        Task AddGroomingPackage(GroomingPackage groomingPackage);

        Task<List<GroomingPackage>> GetAllGroomingPackages();

        Task UpdateGroomingPackage(GroomingPackage groomingPackage);

        Task DeleteGroomingPackage(int groomingPackageId);
    }
}
