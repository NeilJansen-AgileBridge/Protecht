using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProTecht.People
{
    public abstract class PersonCreateDtoBase
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
    }
}