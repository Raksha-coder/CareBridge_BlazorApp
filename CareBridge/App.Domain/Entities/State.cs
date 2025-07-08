using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public Country Country { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
    }
}
