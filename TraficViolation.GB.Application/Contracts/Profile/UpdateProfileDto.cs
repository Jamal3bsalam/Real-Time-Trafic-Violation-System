using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficViolation.GB.Application.Contracts.Profile
{
    public class UpdateProfileDto
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters.")]
        public string? FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 20 digits.")]
        public string? PhoneNumber { get; set; }
    }
}
