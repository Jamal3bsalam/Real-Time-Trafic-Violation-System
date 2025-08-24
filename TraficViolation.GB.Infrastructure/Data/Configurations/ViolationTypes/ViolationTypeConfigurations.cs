using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.ViolationTypes
{
    public class ViolationTypeConfigurations : IEntityTypeConfiguration<ViolationType>
    {
        public void Configure(EntityTypeBuilder<ViolationType> builder)
        {
            builder.HasKey(V => V.Id);
            builder.Property(V => V.Id).UseIdentityColumn(1, 1);

            

        }
    }
}
