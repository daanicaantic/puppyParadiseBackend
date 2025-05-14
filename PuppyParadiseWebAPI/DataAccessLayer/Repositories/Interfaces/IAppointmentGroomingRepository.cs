using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAppointmentGroomingRepository : IRepository<AppointmentGrooming>
    {
        Task<AppointmentGrooming> GetAppointmentGroomingById(int id);
        Task<List<AppointmentGrooming>> GetAllAppointmentGroomings();
    }
}
