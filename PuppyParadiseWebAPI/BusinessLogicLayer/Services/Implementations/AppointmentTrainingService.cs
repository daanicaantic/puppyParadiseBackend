using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.CommonDTOs;
using DomainLayer.Helpers;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentTrainingService : IAppointmentTrainingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentTrainingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
