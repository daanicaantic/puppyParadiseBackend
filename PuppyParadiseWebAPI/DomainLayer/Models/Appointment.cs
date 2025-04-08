using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public double TotalPrice { get; set; }

        public IList<AppointmentService> AppointmentServices { get; set; }

    }
}
