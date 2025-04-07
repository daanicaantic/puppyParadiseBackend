using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class WalkingDetails
    {
        public int Id { get; set; }

        public TimeSpan Duration { get; set; } // koliko traje setnja

        public DateTime PickupTime { get; set; }

        public string PickupAddress { get; set; }

        public string ReturnAddress { get; set; }

        public double Price { get; set; }
    }
}
