using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace ProTecht.People
{
    public abstract class PersonManagerBase : DomainService
    {
        protected IPersonRepository _personRepository;

        public PersonManagerBase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public virtual async Task<Person> CreateAsync(
        Guid personId, string name, string surname, int age, string? contactNumber = null, string? vehicleRegistration = null, string? vehicleType = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(surname, nameof(surname));

            var person = new Person(
             GuidGenerator.Create(),
             personId, name, surname, age, contactNumber, vehicleRegistration, vehicleType
             );

            return await _personRepository.InsertAsync(person);
        }

        public virtual async Task<Person> UpdateAsync(
            Guid id,
            Guid personId, string name, string surname, int age, string? contactNumber = null, string? vehicleRegistration = null, string? vehicleType = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(surname, nameof(surname));

            var person = await _personRepository.GetAsync(id);

            person.PersonId = personId;
            person.Name = name;
            person.Surname = surname;
            person.Age = age;
            person.ContactNumber = contactNumber;
            person.VehicleRegistration = vehicleRegistration;
            person.VehicleType = vehicleType;

            person.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _personRepository.UpdateAsync(person);
        }

    }
}