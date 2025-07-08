using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Otp
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
