using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AppointmentWalkingRepository : Repository<AppointmentWalking>, IAppointmentWalkingRepository
    {
        public AppointmentWalkingRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {

        }

        public async Task<List<AppointmentWalking>> GetAllAppointmentWalkings()
        {
            return await _puppyParadiseContext.AppointmentWalkings
                   .Include(a => a.Dog)
                   .Include(a => a.User)
                   .Include(a => a.WalkingPackage)
                   .ToListAsync();
        }

        public async Task<AppointmentWalking> GetAppointmentWalkingById(int id)
        {
            var appointment =  await _puppyParadiseContext.AppointmentWalkings
                  .Include(a => a.Dog)
                  .Include(a => a.User)
                  .Include(a => a.WalkingPackage)
                  .FirstOrDefaultAsync(a => a.Id == id);

            return appointment;
        }
    }
}
