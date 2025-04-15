using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class TrainingPackageRepository : Repository<TrainingPackage>, ITrainingPackageRepository
    {
        public TrainingPackageRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public void UpdateTrainingPackage(TrainingPackage tpOld, TrainingPackage tpNew)
        {
            tpOld.Name = tpNew.Name;
            tpOld.Description = tpNew.Description;
            tpOld.DurationInWeeks = tpNew.DurationInWeeks;
            tpOld.SessionsPerWeek = tpNew.SessionsPerWeek;
            tpOld.SessionDuration = tpNew.SessionDuration;
            tpOld.Price = tpNew.Price;
        }
    }
}
