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

        //public double Amount { get; set; }
        public string ClientId { get; set; }
        public string Date { get; set; }
        public int Age { get; set; }

        public static QuoteCreateDto Create(string clientId, string date, int age)
        {
            return new QuoteCreateDto
            {
                //Amount = amount,
                ClientId = clientId,
                Date = date, 
                Age = age
            };
        }
    }
}