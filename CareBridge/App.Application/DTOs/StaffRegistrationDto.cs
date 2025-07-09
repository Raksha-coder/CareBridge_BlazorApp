using System.ComponentModel.DataAnnotations;

namespace App.Application.DTOs
{
    public class StaffRegistrationDto
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First Name must contain only letters.")]

        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Last Name must contain only letters.")]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit Mobile Number.")]
        public string PhoneNo { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Designation must contain only letters.")]
        public string Designation { get; set; } // e.g., Doctor, Nurse

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Department must contain only letters.")]
        public string Department { get; set; } // e.g., Cardiology

        [Required]
        [Range(0, 10000)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Visiting charge must be a valid decimal number with up to two decimal places.")]
        public decimal VisitingCharge { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Required]
        public int RoleId { get; set; } // Staff/Doctor role reference

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public int StateId { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "City must contain only letters.")]
        public string City { get; set; }

        public int CountryId { get; set; }
    }
}
