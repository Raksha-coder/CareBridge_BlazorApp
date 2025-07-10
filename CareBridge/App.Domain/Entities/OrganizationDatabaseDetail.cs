using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class OrganizationDatabaseDetail : BaseEntity
    {
        [Key]
        public int DatabaseDetailId { get; set; }

        [ForeignKey("OrganizationRequest")]
        public int OrganizationId { get; set; }
        public OrganizationRequest OrganizationRequest { get; set; }

        [MaxLength(100)]
        [Required]
        public string ServerName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        public string DatabaseName { get; set; } = string.Empty;

        [Required]
        public string ConnectionString { get; set; } = string.Empty;

    }
}
