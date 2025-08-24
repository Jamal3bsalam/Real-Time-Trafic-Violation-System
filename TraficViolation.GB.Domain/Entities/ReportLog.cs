using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;

namespace TraficViolation.GB.Domain.Entities
{
    public class ReportLog
    {
        public int Id { get; set; } // Primary Key
        public string ReportType { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public string? ReceiverEmail { get; set; }
        public bool SentByEmail { get; set; } = false;
        public string? EmailStatus { get; set; }
        public string? ErrorMessage { get; set; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

    }
}
