using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentWalkingDTOs
{
    public class AddAppointmentWalkingDTO
    {
        public int DogId { get; set; }
        public DateOnly PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public string PickupAddress { get; set; }
        public string ReturnAddress { get; set; }
        public int WalkingPackageId { get; set; }
        public string Note { get; set; }
    }
}
