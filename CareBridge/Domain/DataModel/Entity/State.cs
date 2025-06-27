using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModel.Entity
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
