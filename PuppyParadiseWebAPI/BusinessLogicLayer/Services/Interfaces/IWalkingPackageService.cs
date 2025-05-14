using DomainLayer.DTOs.WalkingPackageDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IWalkingPackageService
    {
        Task<WalkingPackage> GetWalkingPackageById(int walkingPackageId);

        Task AddWalkingPackage(AddWalkingPackageDTO walkingPackageWithoutIdDTO);

        Task<List<GetWalkingPackageDTO>> GetAllWalkingPackages();

        Task UpdateWalkingPackage(GetWalkingPackageDTO walkingPackageDTO);

        Task DeleteWalkingPackage(int walkingPackageId);
    }
}
