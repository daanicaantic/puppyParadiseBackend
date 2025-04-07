using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class GroomingPackage
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public double SmallDogPrice { get; set; }

        public double MediumDogPrice { get; set; }

        public double LargeDogPrice { get; set; }

        public List<GroomingPackageService> IncludedServices { get; set; }
    }
}
