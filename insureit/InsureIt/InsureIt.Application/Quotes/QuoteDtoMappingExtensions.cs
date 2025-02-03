using AutoMapper;
using InsureIt.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace InsureIt.Application.Quotes
{
    public static class QuoteDtoMappingExtensions
    {
        public static QuoteDto MapToQuoteDto(this Quote projectFrom, IMapper mapper)
            => mapper.Map<QuoteDto>(projectFrom);

        public static List<QuoteDto> MapToQuoteDtoList(this IEnumerable<Quote> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToQuoteDto(mapper)).ToList();
    }
}