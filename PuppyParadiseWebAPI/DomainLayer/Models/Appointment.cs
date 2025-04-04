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

        public int ServiceTypeId { get; set; }

        public ServiceType ServiceType { get; set; }

        public DateTime AppointmentDate { get; set; }

        public double TotalPrice { get; set; }

        public int? Time { get; set; }

        public int? GroomingPackageId { get; set; }

        public GroomingPackage GroomingPackage { get; set; }

        public List<GroomingService>? ExtraGroomingServices { get; set; }
    }
}
