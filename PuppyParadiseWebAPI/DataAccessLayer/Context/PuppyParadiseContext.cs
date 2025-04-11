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

        public DbSet<DogSize> DogSizes { get; set; }

        public DbSet<GroomingService> GroomingServices { get; set; }

        public DbSet<GroomingPackage> GroomingPackages { get; set; }

        public DbSet<AppointmentGrooming> AppointmentGroomings { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<SittingPackage> SittingPackages { get; set; }

        public DbSet<AppointmentSitting> AppointmentSittings { get; set; }

        public DbSet<WalkingPackage> WalkingPackages { get; set; }

        public DbSet<AppointmentWalking> AppointmentWalkings { get; set; }

        public DbSet<TrainingPackage> TrainingPackages { get; set; }

        public DbSet<AppointmentTraining> AppointmentTrainings { get; set; }

        public DbSet<GroomingServiceAppointment> GroomingServiceAppointments { get; set; }

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

            modelBuilder.Entity<AppointmentGrooming>()
            .HasOne(ag => ag.User)
            .WithMany()
            .HasForeignKey(ag => ag.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentGrooming>()
            .HasOne(ag => ag.Dog)
            .WithMany()
            .HasForeignKey(ag => ag.DogId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentGrooming>()
            .HasOne(ag => ag.GroomingPackage)
            .WithMany()
            .HasForeignKey(ag => ag.GroomingPackageId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentSitting>()
            .HasOne(ag => ag.User)
            .WithMany()
            .HasForeignKey(ag => ag.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentSitting>()
            .HasOne(ag => ag.Dog)
            .WithMany()
            .HasForeignKey(ag => ag.DogId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentTraining>()
            .HasOne(ag => ag.User)
            .WithMany()
            .HasForeignKey(ag => ag.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentTraining>()
            .HasOne(ag => ag.Dog)
            .WithMany()
            .HasForeignKey(ag => ag.DogId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentWalking>()
            .HasOne(ag => ag.User)
            .WithMany()
            .HasForeignKey(ag => ag.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppointmentWalking>()
            .HasOne(ag => ag.Dog)
            .WithMany()
            .HasForeignKey(ag => ag.DogId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
