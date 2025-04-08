using DataAccessLayer.Seeding;
using DomainLayer.Constants;
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

            RoleSeeder.SeedRoles(modelBuilder);

            ServiceTypeSeeder.SeedServiceType(modelBuilder);

            DogSizeSeeder.SeedDogSizes(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()  // Now Role has Users collection
                .HasForeignKey(u => u.RoleId);
        }
    }
}
