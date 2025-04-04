using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Constants;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Seeding
{
    public static class RoleSeeder
    {
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = ConstRoles.Owner },
                new Role { Id = 2, Name = ConstRoles.Staff },
                new Role { Id = 3, Name = ConstRoles.Admin }
            );
        }
    }
}
