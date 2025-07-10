using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.DTOs
{
    public class OrganizationRequestDto
    {
        public int TenantID { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address1 { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(20)]
        public string ApartmentNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Zip { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required, EmailAddress]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

    }
}
