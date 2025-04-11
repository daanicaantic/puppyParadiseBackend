using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class WalkingPackage
    {
        public int Id { get; set; }

        public string Name { get; set; } //30min / 60min

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
