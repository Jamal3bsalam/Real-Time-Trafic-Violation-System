using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;

namespace TraficViolation.GB.Infrastructure.Data.Configurations.ReportLogs
{
    public class ReportLogsConfigurations : IEntityTypeConfiguration<ReportLog>
    {
        public void Configure(EntityTypeBuilder<ReportLog> builder)
        {
            builder.HasKey(V => V.Id);
            builder.Property(V => V.Id).UseIdentityColumn(1, 1);

            builder.HasOne(R => R.User)
                   .WithMany(A => A.ReportLogs)
                   .HasForeignKey(R => R.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
