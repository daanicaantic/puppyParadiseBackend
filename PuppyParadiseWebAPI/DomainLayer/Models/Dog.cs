using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public double Weight { get; set; }

        public int DogSizeId { get; set; }

        public DogSize DogSize { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        [JsonIgnore]
        public List<AppointmentSitting>? AppointmentSittings { get; set; }
    }
}
