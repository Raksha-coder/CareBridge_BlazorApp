using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class VerifyOtpDto
    {
        public string? UserName { get; set; }
        [Required(ErrorMessage = "OTP is required")]
        public string? Otp { get; set; }
    }
}
