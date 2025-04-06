﻿using DomainLayer.Constants;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public static class ServiceTypeSeeder
    {
        public static void SeedServiceType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { Id = 1, Name = ConstServiceTypes.Grooming },
                new ServiceType { Id = 2, Name = ConstServiceTypes.Walking },
                new ServiceType { Id = 3, Name = ConstServiceTypes.Sitting },
                new ServiceType { Id = 4, Name = ConstServiceTypes.Training }
            );
        }
    }
}
