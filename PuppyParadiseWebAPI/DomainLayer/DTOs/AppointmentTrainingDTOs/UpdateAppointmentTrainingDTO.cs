using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentTrainingDTOs
{
    public class UpdateAppointmentTrainingDTO
    {
        public int Id { get; set; }
        public int TrainingPackageId { get; set; }
        public DateOnly StartDate { get; set; }
        public string? Note { get; set; }
    }
}
