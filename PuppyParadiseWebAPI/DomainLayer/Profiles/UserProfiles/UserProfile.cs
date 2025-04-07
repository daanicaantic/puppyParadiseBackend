using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.UserProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                   .ForMember(dest => dest.RoleName,
                       opt => opt.MapFrom(src => src.Role.Name))
                   .ReverseMap();
        }
    }
}
