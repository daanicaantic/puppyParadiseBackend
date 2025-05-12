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
    public class AppointmentGroomingRepository : Repository<AppointmentGrooming>, IAppointmentGroomingRepository
    {
        public AppointmentGroomingRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<List<AppointmentGrooming>> GetAllAppointmentGroomings()
        {
            return await _puppyParadiseContext.AppointmentGroomings
                    .Include(a => a.Dog)
                    .Include(a => a.User)
                    .Include(a => a.GroomingPackage)
                    .Include(a => a.ExtraServices)!
                        .ThenInclude(es => es.GroomingService)
                    .ToListAsync();

        }

        public async Task<AppointmentGrooming> GetAppointmentGroomingById(int id)
        {
            var groomingAppointments = await _puppyParadiseContext.AppointmentGroomings
                    .Include(a => a.Dog)
                    .Include(a => a.User)
                    .Include(a => a.GroomingPackage)
                    .Include(a => a.ExtraServices)!
                        .ThenInclude(es => es.GroomingService)
                    .FirstOrDefaultAsync(a => a.Id == id);

            return groomingAppointments;
        }
    }
}
