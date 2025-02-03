using System;

namespace ProTecht.People
{
    public abstract class PersonExcelDtoBase
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? VehicleRegistration { get; set; }
        public string? VehicleType { get; set; }
        public int Age { get; set; }
    }
}