using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class DogSize
    {
        public int Id { get; set; }

        public string Name { get; set; } // Small, Medium, Large

        public double MinWeight { get; set; }

        public double MaxWeight { get; set; }
    }
}
