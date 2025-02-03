using AutoMapper;
using InsureIt.Application.Common.Mappings;
using InsureIt.Domain;
using InsureIt.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace InsureIt.Application.Quotes
{
    public class QuoteDto : IMapFrom<Quote>
    {
        public QuoteDto()
        {
            VehicleReg = null!;
        }

        public double Price { get; set; }
        public DateOnly Date { get; set; }
        public VehicleType VehicleType { get; set; }
        public Guid CustomerId { get; set; }
        public Guid Id { get; set; }
        public string VehicleReg { get; set; }

        public static QuoteDto Create(
            double price,
            DateOnly date,
            VehicleType vehicleType,
            Guid customerId,
            Guid id,
            string vehicleReg)
        {
            return new QuoteDto
            {
                Price = price,
                Date = date,
                VehicleType = vehicleType,
                CustomerId = customerId,
                Id = id,
                VehicleReg = vehicleReg
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quote, QuoteDto>();
        }
    }
}