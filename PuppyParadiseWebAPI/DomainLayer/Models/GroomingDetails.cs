using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class GroomingDetails
    {
        public int Id { get; set; }

        public int GroomingPackageId { get; set; }

        public GroomingPackage Package { get; set; }

        public ICollection<GroomingService> ExtraServices { get; set; }

        public double Price { get; set; }

    }
}
