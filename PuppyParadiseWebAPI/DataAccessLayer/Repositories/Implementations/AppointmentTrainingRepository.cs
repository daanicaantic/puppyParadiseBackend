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
        public AppointmentTrainingRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
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
    }
}
