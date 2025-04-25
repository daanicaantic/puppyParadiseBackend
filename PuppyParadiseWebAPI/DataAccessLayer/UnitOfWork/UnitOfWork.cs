using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PuppyParadiseContext _puppyParadiseContext;

        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IDogRepository Dogs { get; private set; }
        public IDogSizeRepository DogSizes { get; private set; }
        public IGroomingPackageRepository GroomingPackages { get; private set; }
        public IGroomingServiceRepository GroomingServices { get; private set; }
        public IGroomingServiceAppointmentRepository GroomingServiceAppointments { get; private set; }
        public ISittingPackageRepository SittingPackages { get; private set; }
        public ITrainingPackageRepository TrainingPackages { get; private set; }
        public IWalkingPackageRepository WalkingPackages { get; private set; }
        public IAppointmentGroomingRepository GroomingAppointments { get; private set; }
        public IAppointmentSittingRepository SittingAppointments { get; private set; }
        public IAppointmentTrainingRepository TrainingAppointments { get; private set; }
        public IAppointmentWalkingRepository WalkingAppointments { get; private set; }

        public UnitOfWork(PuppyParadiseContext puppyParadiseContext,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IDogRepository dogRepository,
            IDogSizeRepository dogSizeRepository,
            IGroomingPackageRepository groomingPackageRepository,
            IGroomingServiceRepository groomingServiceRepository,
            IGroomingServiceAppointmentRepository groomingServiceAppointmentRepository,
            ISittingPackageRepository sittingPackageRepository,
            ITrainingPackageRepository trainingPackageRepository,
            IWalkingPackageRepository walkingPackageRepository,
            IAppointmentGroomingRepository appointmentGroomingRepository,
            IAppointmentSittingRepository appointmentSittingRepository,
            IAppointmentTrainingRepository appointmentTrainingRepository,
            IAppointmentWalkingRepository appointmentWalkingRepository)
        {
            _puppyParadiseContext = puppyParadiseContext;
            Users = userRepository;
            Roles = roleRepository;
            Dogs = dogRepository;
            DogSizes = dogSizeRepository;
            GroomingPackages = groomingPackageRepository;
            GroomingServices = groomingServiceRepository;
            GroomingServiceAppointments = groomingServiceAppointmentRepository;
            SittingPackages = sittingPackageRepository;
            TrainingPackages = trainingPackageRepository;
            WalkingPackages = walkingPackageRepository;
            GroomingAppointments = appointmentGroomingRepository;
            SittingAppointments = appointmentSittingRepository;
            TrainingAppointments = appointmentTrainingRepository;
            WalkingAppointments = appointmentWalkingRepository;
        }

        public void Dispose()
        {
            _puppyParadiseContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _puppyParadiseContext.SaveChangesAsync();
        }
    }
}
