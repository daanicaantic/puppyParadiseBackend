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
    public class AddDogProfile : Profile
    {
        public AddDogProfile()
        {
            CreateMap<DogWithoutIdDTO, Dog>();
        }
    }
}
