using AutoMapper;
using DomainLayer.DTOs.DogDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Profiles.DogProfiles
{
    public  class DogProfile : Profile
    {
        public DogProfile() 
        {
            CreateMap<Dog, DogDTO>()
                .ForMember(dest => dest.DogSize, opt => opt.MapFrom(src => src.DogSize.Name))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dest => dest.OwnerSurname, opt => opt.MapFrom(src => src.Owner.Surname));
        }
    }
}
