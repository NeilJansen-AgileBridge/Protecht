using Intent.RoslynWeaver.Attributes;
using VehiCover.Application.Quotes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.ServiceContract", Version = "1.0")]

namespace VehiCover.Application.Interfaces
{
    public interface IQuotesService
    {
        Task<double> CreateQuote(QuoteCreateDto dto, CancellationToken cancellationToken = default);
        Task<QuoteDto> FindQuoteById(Guid id, CancellationToken cancellationToken = default);
        Task<List<QuoteDto>> FindQuotes(CancellationToken cancellationToken = default);
        Task UpdateQuote(Guid id, QuoteUpdateDto dto, CancellationToken cancellationToken = default);
        Task DeleteQuote(Guid id, CancellationToken cancellationToken = default);
    }
}