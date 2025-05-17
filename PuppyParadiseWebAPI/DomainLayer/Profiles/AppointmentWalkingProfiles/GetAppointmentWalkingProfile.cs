using AutoMapper;
using DomainLayer.DTOs.AppointmentWalkingDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Profiles.AppointmentWalkingProfile.cs
{
    public class GetAppointmentWalkingProfile : Profile
    {
        public GetAppointmentWalkingProfile()
        {
            CreateMap<AppointmentWalking, GetAppointmentWalkingDTO>()
                .ForMember(dest => dest.DogName, opt => opt.MapFrom(src => src.Dog.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.WalkingPackageName, opt => opt.MapFrom(src => src.WalkingPackage.Name));
        }
    }
}
