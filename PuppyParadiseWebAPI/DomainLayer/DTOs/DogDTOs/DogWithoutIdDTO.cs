using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.DogDTOs
{
    public class DogWithoutIdDTO
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public double Weight { get; set; }
        public int OwnerId { get; set; }
    }
}
