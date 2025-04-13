using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class SittingPackage
    {
        public int Id { get; set; }

        public string Name { get; set; } //PricePerDay/ PricePerHour

        public double Price { get; set; }
    }
}
