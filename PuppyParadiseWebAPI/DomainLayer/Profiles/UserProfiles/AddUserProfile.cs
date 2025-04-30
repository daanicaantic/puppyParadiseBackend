using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.UserProfiles
{
    public class AddUserProfile : Profile
    {
        public AddUserProfile()
        {
            CreateMap<AddUserDTO, User>();
        }
    }
}
