using Domain.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class AppoinmentDto : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
        [Required]
        [MaxLength(100)]
        public string Reason { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime == EndTime)
                yield return new ValidationResult("Start time and end time cannot be the same.", new[] { nameof(StartTime), nameof(EndTime) });

            if (StartTime > EndTime)
                yield return new ValidationResult("Start time cannot be after end time.", new[] { nameof(StartTime), nameof(EndTime) });

            if (StartTime == TimeOnly.MinValue || EndTime == TimeOnly.MinValue)
                yield return new ValidationResult("Start and end times cannot be 00:00.", new[] { nameof(StartTime), nameof(EndTime) });

            if ((EndTime - StartTime).TotalMinutes < 60)
                yield return new ValidationResult("End time must be at least 1 hour after start time.", new[] { nameof(EndTime) });
        }
    }
}
