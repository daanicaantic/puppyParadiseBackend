﻿using DomainLayer.Constants;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class PuppyParadiseContext : DbContext
    { 
        public PuppyParadiseContext(DbContextOptions<PuppyParadiseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<GroomingService> GroomingServices { get; set; }
        public DbSet<GroomingPackage> GroomingPackages { get; set; }
        public DbSet<GroomingPackageService> GroomingPackageServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = ConstRoles.Owner },
                new Role { Id = 2, Name = ConstRoles.Staff },
                new Role { Id = 3, Name = ConstRoles.Admin }
            );
        }
    }
}
