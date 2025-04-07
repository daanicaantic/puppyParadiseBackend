using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class SittingDetails
    {
        public int Id { get; set; }

        public DateTime DropoffTime { get; set; }

        public int NumberOfDays { get; set; }

        public double Price { get; set; }
    }
}
