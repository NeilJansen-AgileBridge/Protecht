using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace VehiCover.Application.Quotes
{
    public class QuoteUpdateDto
    {
        public QuoteUpdateDto()
        {
            ClientId = Guid.NewGuid();
            Date = null!;
        }

        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid ClientId { get; set; }
        public string Date { get; set; }

        public static QuoteUpdateDto Create(Guid id, double amount, Guid clientId, string date)
        {
            return new QuoteUpdateDto
            {
                Id = id,
                Amount = amount,
                ClientId = clientId,
                Date = date
            };
        }
    }
}