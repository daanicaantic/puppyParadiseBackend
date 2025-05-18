using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.AppointmentSittingProfiles
{
    public class UpdateAppointmentSittingProfile : Profile
    {
        public UpdateAppointmentSittingProfile()
        {
            CreateMap<UpdateAppointmentSittingDTO, AppointmentSitting>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DogId, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note ?? string.Empty));
        }
    }
}
