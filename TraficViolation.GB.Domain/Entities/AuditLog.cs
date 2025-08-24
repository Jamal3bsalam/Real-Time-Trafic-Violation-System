using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Domain.Entities
{
    public class AuditLog : BaseEntity<int>
    {
        public string? EntityName { get; set; }         // مثال: "Violation", "VehicleOwner"
        public string? ActionType { get; set; }         // "Create", "Update", "Delete"

        public string? RecordId { get; set; }           // ID بتاع السجل اللي حصل فيه التعديل

        public string? OldValues { get; set; }         // القيم قبل التعديل (Json)
        public string? NewValues { get; set; }         // القيم بعد التعديل (Json)

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string? UserId { get; set; }
        public AppUser? User { get; set; }


    }
}
