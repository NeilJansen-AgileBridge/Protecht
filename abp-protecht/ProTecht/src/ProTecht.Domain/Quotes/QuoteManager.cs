using ProTecht.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace ProTecht.Quotes
{
    public abstract class QuoteManagerBase : DomainService
    {
        protected IQuoteRepository _quoteRepository;

        public QuoteManagerBase(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public virtual async Task<Quote> CreateAsync(
        Guid? personId, Vendor vendor, string? amount = null)
        {
            Check.NotNull(vendor, nameof(vendor));

            var quote = new Quote(
             GuidGenerator.Create(),
             personId, vendor, amount
             );

            return await _quoteRepository.InsertAsync(quote);
        }

        public virtual async Task<Quote> UpdateAsync(
            Guid id,
            Guid? personId, Vendor vendor, string? amount = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(vendor, nameof(vendor));

            var quote = await _quoteRepository.GetAsync(id);

            quote.PersonId = personId;
            quote.Vendor = vendor;
            quote.Amount = amount;

            quote.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _quoteRepository.UpdateAsync(quote);
        }

    }
}