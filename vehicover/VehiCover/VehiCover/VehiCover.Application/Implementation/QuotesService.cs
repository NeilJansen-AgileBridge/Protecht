using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using VehiCover.Application.Interfaces;
using VehiCover.Application.Quotes;
using VehiCover.Domain.Common.Exceptions;
using VehiCover.Domain.Entities;
using VehiCover.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.ServiceImplementation", Version = "1.0")]

namespace VehiCover.Application.Implementation
{
    [IntentManaged(Mode.Merge)]
    public class QuotesService : IQuotesService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public QuotesService(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<double> CreateQuote(QuoteCreateDto dto, CancellationToken cancellationToken = default)
        {
            Random rand = new Random();
            int calculated_amount = rand.Next(1500, 3001);

            if (dto.Age < 25)
            {
                calculated_amount += 500;
            }

            var quote = new Quote
            {
                Amount = calculated_amount,
                ClientId = dto.PersonId,
                Date = DateTime.Now.ToShortDateString()
            };

            _quoteRepository.Add(quote);
            await _quoteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return quote.Amount;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<QuoteDto> FindQuoteById(Guid id, CancellationToken cancellationToken = default)
        {
            var quote = await _quoteRepository.FindByIdAsync(id, cancellationToken);
            if (quote is null)
            {
                throw new NotFoundException($"Could not find Quote '{id}'");
            }
            return quote.MapToQuoteDto(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<QuoteDto>> FindQuotes(CancellationToken cancellationToken = default)
        {
            var quotes = await _quoteRepository.FindAllAsync(cancellationToken);
            return quotes.MapToQuoteDtoList(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task UpdateQuote(Guid id, QuoteUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var quote = await _quoteRepository.FindByIdAsync(id, cancellationToken);
            if (quote is null)
            {
                throw new NotFoundException($"Could not find Quote '{id}'");
            }

            quote.Amount = dto.Amount;
            quote.ClientId = dto.ClientId;
            quote.Date = dto.Date;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task DeleteQuote(Guid id, CancellationToken cancellationToken = default)
        {
            var quote = await _quoteRepository.FindByIdAsync(id, cancellationToken);
            if (quote is null)
            {
                throw new NotFoundException($"Could not find Quote '{id}'");
            }

            _quoteRepository.Remove(quote);
        }
    }
}