using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AppointmentSittingRepository : Repository<AppointmentSitting>, IAppointmentSittingRepository
    {
        private readonly IMapper _mapper;

        public AppointmentSittingRepository(PuppyParadiseContext puppyParadiseContext, IMapper mapper) : base(puppyParadiseContext)
        {
            _mapper = mapper;
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

        public async Task<List<AppointmentSitting>> GetByDogIdAsync(int dogId)
        {
            var sittingAppointmentDog = await _puppyParadiseContext.AppointmentSittings
                .Where(a => a.DogId == dogId)
                .Include(a => a.Dog)
                .Include(a => a.User)
                .ToListAsync();

            return sittingAppointmentDog;
        }

        public async Task<bool> HasOverlappingAppointmentAsync(AppointmentSittingDTO appointment, int? excludeAppointmentId)
        {
            var hasOverlap =  await _puppyParadiseContext.AppointmentSittings
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
            return hasOverlap;
        }

        public async Task<PagedResult<GetAppointmentSittingDTO>> GetSittingAppointmentsAsync(AppointmentQueryParameters query, int currentUserId, bool isAdmin)
        {
            // If not Admin, override UserId to current user's ID
            if (!isAdmin)
                query.UserId = currentUserId;

            var queryable = _puppyParadiseContext.AppointmentSittings
                .Include(x => x.Dog)
                .Include(x => x.User)
                .AsQueryable();

            if (query.UserId.HasValue)
                queryable = queryable.Where(x => x.UserId == query.UserId);

            if (query.DogId.HasValue)
                queryable = queryable.Where(x => x.DogId == query.DogId);

            var totalCount = await queryable.CountAsync();
            var results = await queryable
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            var mapped = _mapper.Map<List<GetAppointmentSittingDTO>>(results);

            return new PagedResult<GetAppointmentSittingDTO>
            {
                Items = mapped,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }
    }
}
