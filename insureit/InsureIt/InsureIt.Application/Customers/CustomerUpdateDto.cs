using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Customers
{
    public class CustomerUpdateDto
    {
        public CustomerUpdateDto()
        {
            Name = null!;
            PhoneNumber = null!;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public static CustomerUpdateDto Create(Guid id, string name, int age, string phoneNumber)
        {
            return new CustomerUpdateDto
            {
                Id = id,
                Name = name,
                Age = age,
                PhoneNumber = phoneNumber
            };
        }
    }
}