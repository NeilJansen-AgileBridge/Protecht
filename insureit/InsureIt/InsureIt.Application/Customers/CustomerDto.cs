using AutoMapper;
using InsureIt.Application.Common.Mappings;
using InsureIt.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Customers
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public CustomerDto()
        {
            Name = null!;
            PhoneNumber = null!;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Id { get; set; }

        public static CustomerDto Create(string name, int age, string phoneNumber, Guid id)
        {
            return new CustomerDto
            {
                Name = name,
                Age = age,
                PhoneNumber = phoneNumber,
                Id = id
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>();
        }
    }
}