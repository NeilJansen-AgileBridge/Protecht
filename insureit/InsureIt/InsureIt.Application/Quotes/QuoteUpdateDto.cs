using InsureIt.Domain;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Quotes
{
    public class QuoteUpdateDto
    {
        public QuoteUpdateDto()
        {
        }

        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateOnly Date { get; set; }
        public VehicleType VehicleType { get; set; }
        public Guid CustomerId { get; set; }

        public static QuoteUpdateDto Create(Guid id, double price, DateOnly date, VehicleType vehicleType, Guid customerId)
        {
            return new QuoteUpdateDto
            {
                Id = id,
                Price = price,
                Date = date,
                VehicleType = vehicleType,
                CustomerId = customerId
            };
        }
    }
}