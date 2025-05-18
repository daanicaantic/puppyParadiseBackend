using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.DTOs.AppointmentSittingDTOs;

namespace DomainLayer.Profiles.AppointmentSittingProfiles
{
    public class AppointmentSittingProfile : Profile
    {
        public AppointmentSittingProfile()
        {
            CreateMap<AddAppointmentSittingDTO, AppointmentSittingDTO>();
        }
    }
}
