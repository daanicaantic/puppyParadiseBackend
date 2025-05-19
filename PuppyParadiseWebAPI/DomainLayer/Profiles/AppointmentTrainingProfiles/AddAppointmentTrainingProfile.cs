using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.AppointmentTrainingProfiles
{
    public class AddAppointmentTrainingProfile : Profile
    {
        public AddAppointmentTrainingProfile()
        {
            CreateMap<AddAppointmentTrainingDTO, AppointmentTraining>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note ?? string.Empty))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());
        }
    }
}
