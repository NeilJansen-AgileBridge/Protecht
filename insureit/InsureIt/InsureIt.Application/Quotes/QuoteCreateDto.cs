using InsureIt.Domain;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Quotes
{
    public class QuoteCreateDto
    {
        public QuoteCreateDto()
        {
            VehicleReg = null!;
        }

        public double Price { get; set; }
        public DateOnly Date { get; set; }
        public VehicleType VehicleType { get; set; }
        public Guid CustomerId { get; set; }
        public string VehicleReg { get; set; }

        public static QuoteCreateDto Create(
            double price,
            DateOnly date,
            VehicleType vehicleType,
            Guid customerId,
            string vehicleReg)
        {
            return new QuoteCreateDto
            {
                Price = price,
                Date = date,
                VehicleType = vehicleType,
                CustomerId = customerId,
                VehicleReg = vehicleReg
            };
        }
    }
}