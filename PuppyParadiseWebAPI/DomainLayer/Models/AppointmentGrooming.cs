using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AppointmentGrooming
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public int GroomingPackageId  { get; set; }

        public GroomingPackage GroomingPackage { get; set; }

        public List<GroomingServiceAppointment>? ExtraServices { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

    }
}
