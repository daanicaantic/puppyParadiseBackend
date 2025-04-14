using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

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
