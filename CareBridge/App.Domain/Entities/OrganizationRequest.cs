using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class OrganizationRequest : BaseEntity
    {
        [Key]
        public int TenantID { get; set; }

        [MaxLength(100)]
        public string OrganizationName { get; set; }

        [MaxLength(200)]
        public string Address1 { get; set; }

        [MaxLength(200)]
        public string Address2 { get; set; }

        [MaxLength(20)]
        public string ApartmentNumber { get; set; }

        [MaxLength(100)]
        public string City { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }

        [MaxLength(20)]
        public string Zip { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
        public bool IsApproved { get; set; }
    }
}
