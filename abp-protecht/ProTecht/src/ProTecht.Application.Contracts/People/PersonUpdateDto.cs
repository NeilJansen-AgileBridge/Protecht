using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ProTecht.People
{
    public abstract class PersonUpdateDtoBase : IHasConcurrencyStamp
    {
        public Guid PersonId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? VehicleRegistration { get; set; }
        public string? VehicleType { get; set; }
        public int Age { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}