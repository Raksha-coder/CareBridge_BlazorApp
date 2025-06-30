using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class PatientRegisterDto
    {
        [Key]
        public int PatientId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, Phone]
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
        public int PinCode { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }
    }
}
