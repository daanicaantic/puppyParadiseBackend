using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentGroomingDTOs
{
    public class GetAppointmentGroomingDTO
    {
        public int Id { get; set; }
        public string DogName { get; set; }
        public string UserName { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string GroomingPackageName { get; set; }
        public List<string> ExtraServices { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
