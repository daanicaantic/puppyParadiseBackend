using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using System.Xml.Linq;

namespace DomainLayer.DTOs.UserDTOs
{
    public class AddUserDTO : UserDTO
    {
        public string Password { get; set; }

        public AddUserDTO()
        {

        }

        public AddUserDTO(string name, string surname, string email, string password, string phoneNumber, int roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
        }
    }
}
