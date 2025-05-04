using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.WalkingPackageDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class WalkingPackageService : IWalkingPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalkingPackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddWalkingPackage(WalkingPackageWithoutIdDTO walkingPackageWithoutIdDTO)
        {
            var walkingPackage = new WalkingPackage
            {
                Name = walkingPackageWithoutIdDTO.Name,
                Description = walkingPackageWithoutIdDTO.Description,
                Price = walkingPackageWithoutIdDTO.Price
            };
            await _unitOfWork.WalkingPackages.Add(walkingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteWalkingPackage(int walkingPackageId)
        {
            var walkingPackage = await GetWalkingPackageById(walkingPackageId);

            _unitOfWork.WalkingPackages.Delete(walkingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<WalkingPackageDTO>> GetAllWalkingPackages()
        {
            return await _unitOfWork.WalkingPackages.GetAllWalkingPackage();
        }

        public async Task<WalkingPackage> GetWalkingPackageById(int walkingPackageId)
        {
            var walkingPackage = await _unitOfWork.WalkingPackages.GetById(walkingPackageId);
            if (walkingPackage == null)
                throw new Exception(WalkingPackageExceptionsConstants.WalkingPackageWithGivenIdNotFound);
            return walkingPackage;
        }

        public async Task UpdateWalkingPackage(WalkingPackageDTO walkingPackageDTO)
        {
            var wpForEdit = await GetWalkingPackageById(walkingPackageDTO.Id);

            wpForEdit.Name = walkingPackageDTO.Name;
            wpForEdit.Description = walkingPackageDTO.Description;
            wpForEdit.Price = walkingPackageDTO.Price;

            _unitOfWork.WalkingPackages.Update(wpForEdit);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
