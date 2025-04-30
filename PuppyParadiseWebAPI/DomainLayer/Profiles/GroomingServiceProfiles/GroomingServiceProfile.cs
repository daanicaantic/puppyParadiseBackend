using AutoMapper;
using DomainLayer.DTOs.GroomingServiceDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Profiles.GroomingServiceProfiles
{
    public class GroomingServiceProfile : Profile
    {
        public GroomingServiceProfile() 
        {
            CreateMap<GroomingServiceWithoutIdDTO, GroomingService>();
        }
    }
}
