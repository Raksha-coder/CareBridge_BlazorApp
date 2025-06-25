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

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Phone]
        public string Mobile { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [MaxLength(5)]
        public string BloodGroup { get; set; }

        [Required]
        public string Gender { get; set; }

        public int RoleId { get; set; } // Could be Patient = 2 in roles table

        [MaxLength(200)]
        public string Address { get; set; }

        [Range(100000, 999999)]
        public int PinCode { get; set; }

        public int StateId { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        public int CountryId { get; set; }
    }
}
