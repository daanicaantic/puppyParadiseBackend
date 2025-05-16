using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentSittingDTOs
{
    public class GetAppointmentSittingDTO
    {
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public double DogWeight { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public DateOnly DropoffDate { get; set; }
        public TimeOnly DropoffTime { get; set; }
        public DateOnly PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
    }
}
