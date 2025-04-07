using DomainLayer.Constants;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public static class DogSizeSeeder
    {
        public static void SeedDogSizes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogSize>().HasData(
                new Role { Id = 1, Name = ConstDogSizes.Small },
                new Role { Id = 2, Name = ConstDogSizes.Medium },
                new Role { Id = 3, Name = ConstDogSizes.Large }
            );
        }
    }
}
