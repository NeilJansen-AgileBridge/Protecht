using AutoMapper;
using InsureIt.Application.Interfaces;
using InsureIt.Application.Quotes;
using InsureIt.Domain.Common.Exceptions;
using InsureIt.Domain.Entities;
using InsureIt.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.ServiceImplementation", Version = "1.0")]

namespace InsureIt.Application.Implementation
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
        public async Task<Guid> CreateQuote(QuoteCreateDto dto, CancellationToken cancellationToken = default)
        {
            var quote = new Quote
            {
                Price = dto.Price,
                Date = dto.Date,
                VehicleType = dto.VehicleType,
                CustomerId = dto.CustomerId,
                VehicleReg = dto.VehicleReg
            };

            _quoteRepository.Add(quote);
            await _quoteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return quote.Id;
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

            quote.Price = dto.Price;
            quote.Date = dto.Date;
            quote.VehicleType = dto.VehicleType;
            quote.CustomerId = dto.CustomerId;
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