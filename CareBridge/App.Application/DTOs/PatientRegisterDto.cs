using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOs
{
    public class PatientRegisterDto
    {
        [Key]
        public int PatientId { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First name must contain only letters.")]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Last name must contain only letters.")]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit Mobile Number.")]
        public string Mobile { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(5)]

        public string BloodGroup { get; set; }

        [Required]
        public string Gender { get; set; }

        public int RoleId { get; set; } // Could be Patient = 2 in roles table

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(100000, 999999)]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Enter a valid 6-digit Pin Code.")]
        public int PinCode { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "City is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "City must contain only letters.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }
    }
}
