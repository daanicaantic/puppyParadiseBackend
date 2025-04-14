using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class GroomingServiceAppointmentRepository : Repository<GroomingServiceAppointment>, IGroomingServiceAppointmentRepository
    {
        public GroomingServiceAppointmentRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }
    }
}
