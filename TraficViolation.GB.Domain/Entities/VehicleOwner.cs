using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Domain.Entities
{
    public class VehicleOwner : BaseEntity<int>
    {
        public string? FullName { get; set; }
        public string? VehicleType { get; set; }
        public string? NationalId { get; set; }
        public string? CarPlateNumber { get; set; }
        public string? Licensenumber { get; set; }
        public AppUser? User { get; set; }
        public string? UserId { get; set; }
        public ICollection<Violation> Violations { get; set; } = new List<Violation>();

    }
}
