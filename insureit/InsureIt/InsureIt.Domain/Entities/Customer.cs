using InsureIt.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace InsureIt.Domain.Entities
{
    public class Customer : IHasDomainEvent
    {
        public Customer()
        {
            Name = null!;
            PhoneNumber = null!;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = [];
    }
}