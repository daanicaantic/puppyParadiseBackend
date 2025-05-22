using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentWalkingDTOs
{
    public class GetAppointmentWalkingDTO
    {
        public int Id {  get; set; }
        public string DogName { get; set; }
        public string UserEmail { get; set; }
        public DateOnly PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public string PickupAddress { get; set; }
        public string ReturnAddress { get; set; }
        public string WalkingPackageName { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}

