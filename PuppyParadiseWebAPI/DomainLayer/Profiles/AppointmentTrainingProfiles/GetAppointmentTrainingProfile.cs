using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.AppointmentSittingDTOs;
using DomainLayer.DTOs.AppointmentTrainingDTOs;
using DomainLayer.Models;

namespace DomainLayer.Profiles.AppointmentTrainingProfiles
{
    public class GetAppointmentTrainingProfile : Profile
    {
        public GetAppointmentTrainingProfile()
        {
            CreateMap<AppointmentTraining, GetAppointmentTrainingDTO>()
                .ForMember(dest => dest.DogName, opt => opt.MapFrom(src => src.Dog.Name))
                .ForMember(dest => dest.DogBreed, opt => opt.MapFrom(src => src.Dog.Breed))
                .ForMember(dest => dest.DogWeight, opt => opt.MapFrom(src => src.Dog.Weight))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.OwnerSurname, opt => opt.MapFrom(src => src.User.Surname));
        }
    }
}
