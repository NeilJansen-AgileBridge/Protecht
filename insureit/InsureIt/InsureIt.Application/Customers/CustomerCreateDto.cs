using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Customers
{
    public class CustomerCreateDto
    {
        public CustomerCreateDto()
        {
            Name = null!;
            PhoneNumber = null!;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public static CustomerCreateDto Create(string name, int age, string phoneNumber)
        {
            return new CustomerCreateDto
            {
                Name = name,
                Age = age,
                PhoneNumber = phoneNumber
            };
        }
    }
}