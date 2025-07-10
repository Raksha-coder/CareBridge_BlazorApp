using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.DTOs
{
    public class OrganizationDatabaseDetailDto
    {
        public int DatabaseDetailId { get; set; }
        public int OrganizationId { get; set; }

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
