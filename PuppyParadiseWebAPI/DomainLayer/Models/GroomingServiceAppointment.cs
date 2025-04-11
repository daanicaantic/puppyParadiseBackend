using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class GroomingServiceAppointment
    {
        public int Id { get; set; }
        public int AppointmentGroomingId { get; set; }
        
        public AppointmentGrooming AppointmentGrooming { get; set; }

        public int GroomingServiceId { get; set; }

        public GroomingService GromingService { get; set; } 
    }
}
