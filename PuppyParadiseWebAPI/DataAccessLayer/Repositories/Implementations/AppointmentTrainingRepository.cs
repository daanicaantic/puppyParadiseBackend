using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AppointmentTrainingRepository : Repository<AppointmentTraining>, IAppointmentTrainingRepository
    {
        private readonly IMapper _mapper;

        public AppointmentTrainingRepository(PuppyParadiseContext puppyParadiseContext, IMapper mapper) : base(puppyParadiseContext)
        {
            _mapper = mapper;
        }

        public async Task<AppointmentTraining> GetTrainingAppointmentByIdAsync(int appointmentId)
        {
            var trainingAppointment = await _puppyParadiseContext.AppointmentTrainings
                .Include(a => a.Dog)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
            return trainingAppointment;
        }

        public async Task<List<AppointmentTraining>> GetByUserIdAsync(int userId)
        {
            var trainingAppointmentUser = await _puppyParadiseContext.AppointmentTrainings
                .Where(a => a.UserId == userId)
                .Include(a => a.Dog)
                .Include(a => a.User)
                .ToListAsync();
            return trainingAppointmentUser;
        }

        public async Task<List<AppointmentTraining>> GetByDogIdAsync(int dogId)
        {
            var trainingAppointmentDog = await _puppyParadiseContext.AppointmentTrainings
                .Where(a => a.DogId == dogId)
                .Include(a => a.Dog)
                .Include(a => a.User)
                .ToListAsync();

            return trainingAppointmentDog;
        }

        public async Task<bool> HasOverlappingAppointmentAsync(int dogId, DateOnly startDate, DateOnly endDate, int? excludeAppointmentId)
        {
            var hasOverlap = await _puppyParadiseContext.AppointmentTrainings
                .Where(a =>
                    a.DogId == dogId && (excludeAppointmentId == null || a.Id != excludeAppointmentId))
                .AnyAsync(a =>
                    // existing start < new end && new start < existing end
                    a.StartDate <= endDate && startDate <= a.EndDate);
            return hasOverlap;
        }

        public async Task<PagedResult<GetAppointmentTrainingDTO>> GetTrainingAppointmentsAsync(AppointmentQueryParameters query, int currentUserId, bool isAdmin)
        {
            // If not Admin, override UserId to current user's ID
            if (!isAdmin)
                query.UserId = currentUserId;

            var queryable = _puppyParadiseContext.AppointmentTrainings
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

            var mapped = _mapper.Map<List<GetAppointmentTrainingDTO>>(results);

            return new PagedResult<GetAppointmentTrainingDTO>
            {
                Items = mapped,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }
    }
}
