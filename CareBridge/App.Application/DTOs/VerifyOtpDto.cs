using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOs
{
    public class VerifyOtpDto
    {
        public string? UserName { get; set; }
        [Required(ErrorMessage = "OTP is required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Enter a valid 6-digit OTP.")]
        public string? Otp { get; set; }
    }
}
