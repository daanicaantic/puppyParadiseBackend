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
    public class TrainingPackageService : ITrainingPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingPackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TrainingPackage> GetTrainingPackageById(int trainingPackageId)
        {
            var trainingPackage = await _unitOfWork.TrainingPackages.GetById(trainingPackageId);
            if (trainingPackage == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageWithGivenIdNotFound);
            return trainingPackage;
        }

        public async Task AddTrainingPackage(TrainingPackage trainingPackage)
        {
            await _unitOfWork.TrainingPackages.Add(trainingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TrainingPackage>> GetAllTrainingPackages()
        {
            var packages = await _unitOfWork.TrainingPackages.GetAll();
            if (packages == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageListNotFound);
            return packages;
        }

        public async Task UpdateTrainingPackage(TrainingPackage trainingPackage)
        {
            var tpForEdit = await _unitOfWork.TrainingPackages.GetById(trainingPackage.Id);
            if (tpForEdit == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageWithGivenIdNotFound);

            _unitOfWork.TrainingPackages.UpdateTrainingPackage(tpForEdit, trainingPackage);

            _unitOfWork.TrainingPackages.Update(tpForEdit);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTrainingPackage(int trainingPackageId)
        {
            var trainingPackage = await _unitOfWork.TrainingPackages.GetById(trainingPackageId);
            if (trainingPackage == null)
                throw new Exception(TrainingPackageExceptionsConstants.TrainingPackageWithGivenIdNotFound);

            _unitOfWork.TrainingPackages.Delete(trainingPackage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
