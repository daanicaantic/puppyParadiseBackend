using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AppointmentWalkingService : IAppointmentWalkingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentWalkingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
