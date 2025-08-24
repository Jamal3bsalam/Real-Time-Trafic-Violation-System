using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.Officers
{
    public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder.HasKey(O => O.Id);
            builder.Property(O => O.Id).UseIdentityColumn(1,1);

            builder.HasMany(O => O.Violations)
                   .WithOne(V => V.Officer)
                   .HasForeignKey(V => V.OfficerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(O => O.AppUser)
                   .WithOne(U => U.Officer)
                   .HasForeignKey<Officer>(O => O.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(O => O.BadgeNumber).IsUnique();
        }
    }
}
