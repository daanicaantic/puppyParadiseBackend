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
    public class AppointmentSittingConfiguration : IEntityTypeConfiguration<AppointmentSitting>
    {
        public void Configure(EntityTypeBuilder<AppointmentSitting> builder)
        {

            builder.HasOne(ag => ag.User)
                   .WithMany()
                   .HasForeignKey(ag => ag.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ag => ag.Dog)
                   .WithMany(x => x.AppointmentSittings)
                   .HasForeignKey(ag => ag.DogId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
