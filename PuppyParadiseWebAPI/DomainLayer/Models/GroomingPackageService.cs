using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class GroomingPackageService
    {
        public int Id { get; set; }

        public int GroomingPackageId { get; set; }

        public GroomingPackage GroomingPackage { get; set; }

        public int GroomingServiceId { get; set; }

        public GroomingService GroomingService { get; set; }
    }
}
