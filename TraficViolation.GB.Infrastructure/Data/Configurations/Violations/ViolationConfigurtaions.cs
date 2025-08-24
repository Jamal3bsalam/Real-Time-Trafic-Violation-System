using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.Violations
{
    public class ViolationConfigurtaions : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.HasKey(V => V.Id);
            builder.Property(V => V.Id).UseIdentityColumn(1, 1);


            builder.HasOne(V => V.VehicleOwner)
                   .WithMany(VO => VO.Violations)
                   .HasForeignKey(V => V.VehicleOwnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(V => V.ViolationType)
                   .WithMany(V => V.Violations)
                   .HasForeignKey(v => v.ViolationTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
                   
        }
    }
}
