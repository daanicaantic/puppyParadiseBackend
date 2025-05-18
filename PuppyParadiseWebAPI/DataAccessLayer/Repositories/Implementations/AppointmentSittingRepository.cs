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

        public async Task<bool> HasOverlappingAppointmentAsync(AppointmentSittingDTO appointment, int? excludeAppointmentId)
        {
            var appointments =  await _puppyParadiseContext.AppointmentSittings
                .Where(a =>
                    a.DogId == appointment.DogId && (excludeAppointmentId == null || a.Id != excludeAppointmentId))
                .AnyAsync(a =>
                    // existing start < new end:
                    (a.DropoffDate < appointment.PickupDate
                    || (a.DropoffDate == appointment.PickupDate && a.DropoffTime < appointment.PickupTime))
                    &&
                    // new start < existing end:
                    (appointment.DropoffDate < a.PickupDate
                    || (appointment.DropoffDate == a.PickupDate && appointment.DropoffTime < a.PickupTime))
                );
            return appointments;
        }
    }
}
