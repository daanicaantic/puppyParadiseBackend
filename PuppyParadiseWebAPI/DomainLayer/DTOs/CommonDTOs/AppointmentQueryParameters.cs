using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.CommonDTOs
{
    public class AppointmentQueryParameters
    {
        public int? UserId { get; set; } // Optional user ID, set only if Admin is logged in
        public int? DogId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
