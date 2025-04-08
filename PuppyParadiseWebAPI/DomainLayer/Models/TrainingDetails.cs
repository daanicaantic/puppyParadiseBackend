using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class TrainingDetails
    {
        public int Id { get; set; }

        public int TrainingPackageId { get; set; }

        public TrainingPackage Package { get; set; }

        public double Price { get; set; }

        //logika za zakazivanje svakog termina pojedinacno
    }
}
