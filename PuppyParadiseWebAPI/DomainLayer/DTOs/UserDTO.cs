using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    public class UpdateUserDTO : UserDTO
    {
        public int Id { get; set; }
    }

    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public UserDTO()
        {

        }
        public UserDTO(string name, string surname, string email, string phoneNumber, int roleId,string roleName)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            RoleName = roleName;
        }
    }
    public class UserWithDogDTO
    {

    }
}
