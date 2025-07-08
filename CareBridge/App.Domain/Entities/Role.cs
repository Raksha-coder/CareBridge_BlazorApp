using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
