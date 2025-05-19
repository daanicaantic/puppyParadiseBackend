using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.AppointmentSittingProfiles
{
    public class AddAppointmentSittingProfile : Profile
    {
        public AddAppointmentSittingProfile()
        {
            CreateMap<AddAppointmentSittingDTO, AppointmentSitting>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note ?? string.Empty))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());
        }
    }
}
