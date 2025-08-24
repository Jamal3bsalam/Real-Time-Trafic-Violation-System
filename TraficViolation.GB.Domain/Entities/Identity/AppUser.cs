using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficViolation.GB.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
        public VehicleOwner? VehicleOwner { get; set; }
        public Officer? Officer { get; set; }
        public ICollection<AuditLog>? AuditLogs { get; set; } = new List<AuditLog>();
        public ICollection<ReportLog>? ReportLogs { get; set; } = new List<ReportLog>();
    }
}
