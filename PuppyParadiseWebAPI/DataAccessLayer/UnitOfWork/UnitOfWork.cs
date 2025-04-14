using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
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

        public IGroomingPackageRepository GroomingPackages { get; private set; }
        
        public UnitOfWork(PuppyParadiseContext puppyParadiseContext,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IGroomingPackageRepository groomingPackages) 
        {
            _puppyParadiseContext = puppyParadiseContext;
            Users = userRepository;
            Roles = roleRepository;
            GroomingPackages = groomingPackages;
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
