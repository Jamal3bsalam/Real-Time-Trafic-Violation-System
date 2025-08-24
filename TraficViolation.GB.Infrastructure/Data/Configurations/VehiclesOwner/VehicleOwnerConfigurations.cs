using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.VehiclesOwner
{
    public class VehicleOwnerConfigurations : IEntityTypeConfiguration<VehicleOwner>
    {
        public void Configure(EntityTypeBuilder<VehicleOwner> builder)
        {
            builder.HasKey(V => V.Id);
            builder.Property(V => V.Id).UseIdentityColumn(1, 1);

            builder.HasIndex(V => V.CarPlateNumber).IsUnique();
            builder.HasIndex(V => V.NationalId).IsUnique();

        }
    }
}
