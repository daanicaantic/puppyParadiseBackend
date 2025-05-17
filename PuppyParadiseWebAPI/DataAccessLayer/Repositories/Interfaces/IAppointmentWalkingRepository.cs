using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAppointmentWalkingRepository : IRepository<AppointmentWalking>
    {
        Task<AppointmentWalking> GetAppointmentWalkingById(int id);
        Task<List<AppointmentWalking>> GetAllAppointmentWalkings();
    }
}
