using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.GroomingPackageDTOs;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class GroomingPackageService : IGroomingPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroomingPackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GroomingPackage> GetGroomingPackageById(int groomingPackageId)
        {
            var groomingPackage = await _unitOfWork.GroomingPackages.GetById(groomingPackageId);
            if (groomingPackage == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);
            return groomingPackage;
        }

        public async Task AddGroomingPackage(GroomingPackage groomingPackage)
        {
            await _unitOfWork.GroomingPackages.Add(groomingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GroomingPackage>> GetAllGroomingPackages()
        {
            var packages = await _unitOfWork.GroomingPackages.GetAll();
            if(packages == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageListNotFound);
            return packages;
        }

        public async Task UpdateGroomingPackage(GroomingPackage groomingPackage)
        {
            var gpForEdit = await _unitOfWork.GroomingPackages.GetById(groomingPackage.Id);
            if (gpForEdit == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);

            _unitOfWork.GroomingPackages.UpdateGroomingPackage(gpForEdit, groomingPackage);

            _unitOfWork.GroomingPackages.Update(gpForEdit);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteGroomingPackage(int groomingPackageId)
        {
            var groomingPackage = await _unitOfWork.GroomingPackages.GetById(groomingPackageId);
            if (groomingPackage == null)
                throw new Exception(GroomingPackageExceptionsConstants.GroomingPackageWithGivenIdNotFound);

            _unitOfWork.GroomingPackages.Delete(groomingPackage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
