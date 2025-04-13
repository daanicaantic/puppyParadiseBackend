using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class AppointmentGroomingConfiguration : IEntityTypeConfiguration<AppointmentGrooming>
    {
        public void Configure(EntityTypeBuilder<AppointmentGrooming> builder)
        {
            builder.HasOne(ag => ag.User)
                   .WithMany()
                   .HasForeignKey(ag => ag.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ag => ag.Dog)
                   .WithMany()
                   .HasForeignKey(ag => ag.DogId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ag => ag.GroomingPackage)
                   .WithMany()
                   .HasForeignKey(ag => ag.GroomingPackageId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
