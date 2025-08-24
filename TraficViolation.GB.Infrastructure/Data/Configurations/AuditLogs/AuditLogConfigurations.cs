using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.AuditLogs
{
    public class AuditLogConfigurations : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(A => A.Id);
            builder.Property(A => A.Id).UseIdentityColumn(1, 1);

            builder.HasOne(A => A.User)
                   .WithMany(A => A.AuditLogs)
                   .HasForeignKey(R => R.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
