﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.AppointmentSittingDTOs
{
    public class UpdateAppointmentSittingDTO
    {
        public int Id { get; set; }
        public DateOnly DropoffDate { get; set; }
        public TimeOnly DropoffTime { get; set; }
        public DateOnly PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public string? Note { get; set; }
    }
}
