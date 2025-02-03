using Intent.RoslynWeaver.Attributes;
using VehiCover.Domain.Common;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace VehiCover.Domain.Entities
{
    public class Quote : IHasDomainEvent
    {
        public Quote()
        {
            ClientId = null!;
            Date = null!;
        }

        public Guid Id { get; set; }

        public double Amount { get; set; }

        public string ClientId { get; set; }

        public string Date { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = [];
    }
}