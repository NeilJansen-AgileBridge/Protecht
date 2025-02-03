using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace ProTecht.People
{
    public abstract class PersonBase : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid PersonId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Surname { get; set; }

        [CanBeNull]
        public virtual string? ContactNumber { get; set; }

        [CanBeNull]
        public virtual string? VehicleRegistration { get; set; }

        [CanBeNull]
        public virtual string? VehicleType { get; set; }

        public virtual int Age { get; set; }

        protected PersonBase()
        {

        }

        public PersonBase(Guid id, Guid personId, string name, string surname, int age, string? contactNumber = null, string? vehicleRegistration = null, string? vehicleType = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(surname, nameof(surname));
            PersonId = personId;
            Name = name;
            Surname = surname;
            Age = age;
            ContactNumber = contactNumber;
            VehicleRegistration = vehicleRegistration;
            VehicleType = vehicleType;
        }

    }
}