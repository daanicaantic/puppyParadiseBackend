using DataAccessLayer.Context;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Repositories.Implementations;

namespace DataAccessLayer.Extensions
{
    public static class DALExtensions
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PuppyParadiseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registracija repozitorijuma i Unit of Work
            services.AddScoped<IUnitOfWork, DataAccessLayer.UnitOfWork.UnitOfWork>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IGroomingPackageRepository, GroomingPackageRepository>();
            services.AddScoped<IGroomingPackageServiceRepository, GroomingPackageServiceRepository>();
            services.AddScoped<IGroomingServiceRepository, GroomingServiceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
