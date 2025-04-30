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
            
            return packages;
        }

        public async Task UpdateTrainingPackage(TrainingPackage trainingPackage)
        {
            var tpForEdit = await GetTrainingPackageById(trainingPackage.Id);

            tpForEdit.Name = trainingPackage.Name;
            tpForEdit.Description = trainingPackage.Description;
            tpForEdit.DurationInWeeks = trainingPackage.DurationInWeeks;
            tpForEdit.SessionsPerWeek = trainingPackage.SessionsPerWeek;
            tpForEdit.SessionDuration = trainingPackage.SessionDuration;
            tpForEdit.Price = trainingPackage.Price;

            _unitOfWork.TrainingPackages.Update(tpForEdit);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTrainingPackage(int trainingPackageId)
        {
            var trainingPackage = await GetTrainingPackageById(trainingPackageId);

            _unitOfWork.TrainingPackages.Delete(trainingPackage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
