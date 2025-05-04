using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IDogRepository Dogs { get; }
        IDogSizeRepository DogSizes { get; }
        IGroomingPackageRepository GroomingPackages { get; }
        IGroomingServiceRepository GroomingServices { get; }
        IGroomingServiceAppointmentRepository GroomingServiceAppointments { get; }
        ISittingPackageRepository SittingPackages { get; }
        ITrainingPackageRepository TrainingPackages { get; }
        IWalkingPackageRepository WalkingPackages { get; }
        IAppointmentGroomingRepository GroomingAppointments { get; }
        IAppointmentSittingRepository SittingAppointments { get; }
        IAppointmentTrainingRepository TrainingAppointments { get; }
        IAppointmentWalkingRepository WalkingAppointments { get; }

        Task SaveChangesAsync();
    }
}
