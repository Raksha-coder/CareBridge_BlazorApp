﻿using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOs
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
