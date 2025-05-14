using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Extensions;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Extensions
{
    public static class BLLExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALServices(configuration);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IGroomingPackageService, GroomingPackageService>();
            services.AddScoped<IGroomingServiceService, GroomingServiceService>();
            services.AddScoped<IGroomingServiceAppointmentService, GroomingServiceAppointmentService>();
            services.AddScoped<ISittingPackageService, SittingPackageService>();
            services.AddScoped<ITrainingPackageService, TrainingPackageService>();
            services.AddScoped<IWalkingPackageService, WalkingPackageService>();
            services.AddScoped<IAppointmentGroomingService, AppointmentGroomingService>();
            services.AddScoped<IAppointmentSittingService, AppointmentSittingService>();
            services.AddScoped<IAppointmentTrainingService, AppointmentTrainingService>();
            services.AddScoped<IAppointmentWalkingService, AppointmentWalkingService>();

            services.AddScoped<IServiceTypeService, ServiceTypeService>();

            return services;
        }
    }
}
