using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AppointmentWalking
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateOnly PickupDate { get; set; }

        public TimeOnly PickupTime { get; set; }

        public string PickupAddress { get; set; }

        public string ReturnAddress { get; set; }

        public int WalkingPackageId { get; set; }

        public WalkingPackage WalkingPackage { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public string Note { get; set; }
    }
}
