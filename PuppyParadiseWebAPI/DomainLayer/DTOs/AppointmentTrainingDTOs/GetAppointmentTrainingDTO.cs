using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentTrainingDTOs
{
    public class GetAppointmentTrainingDTO
    {
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public double DogWeight { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
    }
}
