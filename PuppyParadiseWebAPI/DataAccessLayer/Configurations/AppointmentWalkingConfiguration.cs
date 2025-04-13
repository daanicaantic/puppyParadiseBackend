using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class AppointmentWalkingConfiguration : IEntityTypeConfiguration<AppointmentWalking>
    {
        public void Configure(EntityTypeBuilder<AppointmentWalking> builder)
        {
            builder.HasOne(ag => ag.User)
                   .WithMany()
                   .HasForeignKey(ag => ag.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ag => ag.Dog)
                   .WithMany()
                   .HasForeignKey(ag => ag.DogId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
