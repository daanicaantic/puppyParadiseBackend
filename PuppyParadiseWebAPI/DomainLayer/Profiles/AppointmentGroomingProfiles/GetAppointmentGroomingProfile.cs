using AutoMapper;
using DomainLayer.DTOs.AppointmentGroomingDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Profiles.AppointmentGroomingProfiles
{
    public class GetAppointmentGroomingProfile : Profile
    {
        public GetAppointmentGroomingProfile()
        {
            CreateMap<AppointmentGrooming, GetAppointmentGroomingDTO>()
            .ForMember(dest => dest.DogName, 
                opt => opt.MapFrom(src => src.Dog.Name))
            .ForMember(dest => dest.UserEmail, 
                opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.AppointmentDate,
                opt => opt.MapFrom(src => src.AppointmentDate))
            .ForMember(dest => dest.AppointmentTime,
                opt => opt.MapFrom(src => src.AppointmentTime))
            .ForMember(dest => dest.GroomingPackageName,
                opt => opt.MapFrom(src => src.GroomingPackage.Name))
            .ForMember(dest => dest.ExtraServices,
                opt => opt.MapFrom(src => src.ExtraServices != null
                    ? src.ExtraServices
                        .Where(es => es.GroomingService != null)
                        .Select(es => es.GroomingService.Name)
                        .ToList()
                        : new List<string>()));
        }
    }
}
