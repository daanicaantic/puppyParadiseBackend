using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.UserDTOs
{
    public class GetUserDTO : UserDTO
    {
        public string RoleName { get; set; }

        public GetUserDTO()
        {

        }
        public GetUserDTO(string name, string surname, string email, string phoneNumber, int roleId, string roleName)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            RoleName = roleName;
        }
    }
}
