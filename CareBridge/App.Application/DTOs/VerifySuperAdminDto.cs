using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.DTOs
{
    public class VerifySuperAdminDto
    {
        public string? Email { get; set; }
        [Required(ErrorMessage = "OTP is required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Enter a valid 6-digit OTP.")]
        public string Otp { get; set; }
    }
}
