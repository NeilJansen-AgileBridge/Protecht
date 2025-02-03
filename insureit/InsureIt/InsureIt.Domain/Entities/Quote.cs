using InsureIt.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace InsureIt.Domain.Entities
{
    public class Quote : IHasDomainEvent
    {
        public Quote()
        {
            VehicleReg = null!;
            Customer = null!;
        }

        public Guid Id { get; set; }

        public double Price { get; set; }

        public DateOnly Date { get; set; }

        public VehicleType VehicleType { get; set; }

        public Guid CustomerId { get; set; }

        public string VehicleReg { get; set; }

        public virtual Customer Customer { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = [];
    }
}