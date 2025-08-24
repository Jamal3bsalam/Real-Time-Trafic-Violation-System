using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Domain.Entities
{
    public class Officer : BaseEntity<int>
    {
        public string? BadgeNumber { get; set; }   // رقم الشارة/الكود الخاص بالضابط
        public string? Rank { get; set; }          // الرتبة (ملازم، نقيب، رائد...)
        public string? Department { get; set; }    // القسم/الوحدة اللي بيتبعها
        public DateTime? HireDate { get; set; }    // تاريخ التعيين
        public bool? IsActive { get; set; }

        // العلاقة مع AppUser
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<Violation>? Violations { get; set; } = new List<Violation>();

    }
}
