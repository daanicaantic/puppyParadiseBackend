using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISittingPackageService
    {
        Task<SittingPackage> GetSittingPackageById(int sittingPackageId);

        Task AddSittingPackage(SittingPackage sittingPackage);

        Task<List<SittingPackage>> GetAllSittingPackages();

        Task UpdateSittingPackage(SittingPackage sittingPackage);

        Task DeleteSittingPackage(int sittingPackageId);
    }
}
