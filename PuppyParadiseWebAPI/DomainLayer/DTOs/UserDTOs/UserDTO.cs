using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.UserDTOs
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
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        public UserDTO()
        {

        }
        public UserDTO(string name, string surname, string email, string phoneNumber, int roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
        }
    }
    public class UserWithDogDTO
    {

    }
}
