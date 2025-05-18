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
    public class UpdateUserInfoProfile : Profile
    {
        public UpdateUserInfoProfile()
        {
            CreateMap<UpdateUserInfoDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
