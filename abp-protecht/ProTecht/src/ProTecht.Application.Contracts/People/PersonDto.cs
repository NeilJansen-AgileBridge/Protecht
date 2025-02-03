using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace ProTecht.People
{
    public abstract class PersonDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? VehicleRegistration { get; set; }
        public string? VehicleType { get; set; }
        public int Age { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}