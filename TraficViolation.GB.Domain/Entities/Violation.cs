using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Domain.Entities
{
    public class Violation : BaseEntity<int>
    {
        public string? PlateNumber { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public DateTime ViolationDate { get; set; } = DateTime.UtcNow;
        public int? VehicleOwnerId { get; set; }
        public VehicleOwner? VehicleOwner { get; set; }

        public int? ViolationTypeId { get; set; }
        public ViolationType? ViolationType { get; set; }
        public int? OfficerId { get; set; }
        public Officer? Officer { get; set; }
    }
}
