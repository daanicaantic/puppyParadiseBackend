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
                new DogSize { Id = 1, Name = "Small", MinWeight = 0.0, MaxWeight = 10.0 },
                new DogSize { Id = 2, Name = "Medium", MinWeight = 10.1, MaxWeight = 25.0 },
                new DogSize { Id = 3, Name = "Large", MinWeight = 25.1, MaxWeight = 50.0 }
            );
        }
    }
}
