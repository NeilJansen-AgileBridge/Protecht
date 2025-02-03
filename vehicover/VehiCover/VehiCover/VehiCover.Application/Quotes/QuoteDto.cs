using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using VehiCover.Application.Common.Mappings;
using VehiCover.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace VehiCover.Application.Quotes
{
    public class QuoteDto : IMapFrom<Quote>
    {
        public QuoteDto()
        {
            ClientId = null!;
            Date = null!;
        }

        public double Amount { get; set; }
        public string ClientId { get; set; }
        public string Date { get; set; }
        public Guid Id { get; set; }

        public static QuoteDto Create(double amount, string clientId, string date, Guid id)
        {
            return new QuoteDto
            {
                Amount = amount,
                ClientId = clientId,
                Date = date,
                Id = id
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quote, QuoteDto>();
        }
    }
}