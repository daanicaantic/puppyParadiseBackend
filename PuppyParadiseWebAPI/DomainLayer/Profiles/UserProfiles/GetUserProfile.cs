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
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<User, GetUserDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
