using Domain.DataModel.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Dtos
{
    public class StateDto
    {
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }
}
