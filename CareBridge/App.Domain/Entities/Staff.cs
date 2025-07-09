using System.ComponentModel.DataAnnotations;
using App.Domain.Common;

namespace App.Domain.Entities
{
    public class Staff : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProfileImage { get; set; } = string.Empty;

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
        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required, Phone]
        public string PhoneNo { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; } // e.g., Doctor, Nurse

        [MaxLength(100)]
        public string Department { get; set; } // e.g., Cardiology

        [Range(0, 10000)]
        public decimal VisitingCharge { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        public int RoleId { get; set; } // Staff/Doctor role reference

        public int StateId { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        public int CountryId { get; set; }
    }
}
