using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AppointmentSitting
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateOnly DropoffDate { get; set; }

        public TimeOnly DropoffTime { get; set; }

        public DateOnly PickupDate { get; set; }

        public TimeOnly PickupTime { get; set; }

        public int SittingPackageId { get; set; }

        public SittingPackage SittingPackage { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public string Note { get; set; }
    }
}
