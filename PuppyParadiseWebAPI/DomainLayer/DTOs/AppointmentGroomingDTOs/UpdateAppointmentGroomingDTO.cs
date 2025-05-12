using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentGroomingDTOs
{
    public class UpdateAppointmentGroomingDTO
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public int GroomingPackageId { get; set; }
        public List<int> ExtraServiceIds { get; set; }
    }
}
