using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Domain.Entities
{
    public class ViolationType : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Violation>? Violations { get; set; } = new List<Violation>();
    }
}
