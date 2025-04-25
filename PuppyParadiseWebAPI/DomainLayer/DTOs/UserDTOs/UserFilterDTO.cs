using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.UserDTOs
{
    public class UserFilterDTO
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
