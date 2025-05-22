using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AppointmentTraining
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int TrainingPackageId { get; set; }

        public TrainingPackage TrainingPackage { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public string? Note { get; set; }
    }
}
