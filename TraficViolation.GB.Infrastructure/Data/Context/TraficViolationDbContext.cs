using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities;
using TraficViolation.GB.Domain.Entities.Identity;

namespace TraficViolation.GB.Infrastructure.Data.Context
{
    public class TraficViolationDbContext : IdentityDbContext<AppUser>
    {
        public TraficViolationDbContext(DbContextOptions<TraficViolationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<Violation> Violations { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<ReportLog> ReportLogs { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }
    }
}
