using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AppointmentService
    {   
        public int Id { get; set; }

        public ServiceType Type { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        // Reference na detalje po tipu
        public GroomingDetails GroomingDetails { get; set; }

        public WalkingDetails WalkingDetails { get; set; }

        public SittingDetails SittingDetails { get; set; }

        public TrainingDetails TrainingDetails { get; set; }
    }
}
