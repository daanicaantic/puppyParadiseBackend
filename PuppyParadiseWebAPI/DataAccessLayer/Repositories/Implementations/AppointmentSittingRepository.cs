using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AppointmentSittingRepository : Repository<AppointmentSitting>, IAppointmentSittingRepository
    {
        public AppointmentSittingRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }

        public async Task<AppointmentSitting> GetSittingAppointmentByIdAsync(int appointmentId)
        {
            var sittingAppointment =  await _puppyParadiseContext.AppointmentSittings
                .Include(a => a.Dog)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
            return sittingAppointment;
        }

        public async Task<IEnumerable<AppointmentSitting>> GetByUserIdAsync(int userId)
        {
            var sittingAppointmentUser = await _puppyParadiseContext.AppointmentSittings
                .Where(a => a.UserId == userId)
                .Include(a => a.Dog)
                .Include(a => a.User)
                .ToListAsync();
            return sittingAppointmentUser;
        }

        public async Task<bool> HasOverlappingAppointmentAsync(AppointmentTimeRangeDTO appointment)
        {
            var dropoff = appointment.DropoffDate.ToDateTime(appointment.DropoffTime);
            var pickup = appointment.PickupDate.ToDateTime(appointment.PickupTime);

            var appointments = await _puppyParadiseContext.AppointmentSittings
                .Where(a => a.DogId == appointment.DogId && (appointment.ExcludeAppointmentId == null || a.Id != appointment.ExcludeAppointmentId))
                .ToListAsync();

            return appointments.Any(a =>
            {
                var existingDropoff = a.DropoffDate.ToDateTime(a.DropoffTime);
                var existingPickup = a.PickupDate.ToDateTime(a.PickupTime);

                //The existing appointment starts before the new one ends,
                //And the existing appointment ends after the new one starts.
                return dropoff < existingPickup && existingDropoff < pickup;
            });
        }
    }
}
