using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class SittingPackageService : ISittingPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SittingPackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SittingPackage> GetSittingPackageById(int sittingPackageId)
        {
            var sittingPackage = await _unitOfWork.SittingPackages.GetById(sittingPackageId);
            if (sittingPackage == null)
                throw new Exception(SittingPackageExceptionsConstants.SittingPackageWithGivenIdNotFound);
            return sittingPackage;
        }

        public async Task<SittingPackage> GetSittingPackageByName(string name)
        {
            var sittingPackage = await _unitOfWork.SittingPackages.GetSittingPackageByName(name);
            if (sittingPackage == null)
                throw new Exception(SittingPackageExceptionsConstants.SittingPackageWithGivenIdNotFound);
            return sittingPackage;
        }

        public async Task AddSittingPackage(SittingPackage sittingPackage)
        {
            await _unitOfWork.SittingPackages.Add(sittingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SittingPackage>> GetAllSittingPackages()
        {
            var packages = await _unitOfWork.SittingPackages.GetAll();
            
            return packages;
        }

        public async Task UpdateSittingPackage(SittingPackage sittingPackage)
        {
            var spForEdit = await GetSittingPackageById(sittingPackage.Id);

            spForEdit.Name = sittingPackage.Name;
            spForEdit.Price = sittingPackage.Price;

            _unitOfWork.SittingPackages.Update(spForEdit);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSittingPackage(int sittingPackageId)
        {
            var sittingPackage = await GetSittingPackageById(sittingPackageId);

            _unitOfWork.SittingPackages.Delete(sittingPackage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
