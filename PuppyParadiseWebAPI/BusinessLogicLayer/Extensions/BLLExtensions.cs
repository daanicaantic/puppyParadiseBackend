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

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IGroomingPackageService, GroomingPackageService>();
            services.AddScoped<IGroomingPackageServiceService, GroomingPackageServiceService>();
            services.AddScoped<IGroomingServiceService, GroomingServiceService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
