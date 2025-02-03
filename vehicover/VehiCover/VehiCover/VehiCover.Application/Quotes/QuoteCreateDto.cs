using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace VehiCover.Application.Quotes
{
    public class QuoteCreateDto
    {
        public QuoteCreateDto()
        {
            ClientId = null!;
            Date = null!;
        }

        public double Amount { get; set; }
        public string ClientId { get; set; }
        public string Date { get; set; }

        public static QuoteCreateDto Create(double amount, string clientId, string date)
        {
            return new QuoteCreateDto
            {
                Amount = amount,
                ClientId = clientId,
                Date = date
            };
        }
    }
}