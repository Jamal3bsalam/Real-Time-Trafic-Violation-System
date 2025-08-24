using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficViolation.GB.Application.Contracts.User
{
    public class RegisterDto
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email Is Required !!")]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 20 digits.")]
        public string? PhoneNumber { get; set; }
        public string? NationalId { get; set; }
        public string? VehiclePlateNumber { get; set; }
        public string? Licensenumber { get; set; }
        public string? VehicleType { get; set; }
        [Required(ErrorMessage = "Password Is Required !!")]
        [MinLength(6, ErrorMessage = "Password must be at least 4 characters long.")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password don't match with ConfirmPassword")]
        public string? ConfirmPassword { get; set; }
        
    }
}
