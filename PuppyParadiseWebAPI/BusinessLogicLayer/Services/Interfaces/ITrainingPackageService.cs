using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ITrainingPackageService
    {
        Task<TrainingPackage> GetTrainingPackageById(int trainingPackageId);

        Task AddTrainingPackage(TrainingPackage trainingPackage);

        Task<List<TrainingPackage>> GetAllTrainingPackages();

        Task UpdateTrainingPackage(TrainingPackage trainingPackage);

        Task DeleteTrainingPackage(int trainingPackageId);
    }
}
