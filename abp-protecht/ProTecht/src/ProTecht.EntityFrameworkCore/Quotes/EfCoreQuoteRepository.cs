using ProTecht.Enum;
using ProTecht.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ProTecht.EntityFrameworkCore;

namespace ProTecht.Quotes
{
    public abstract class EfCoreQuoteRepositoryBase : EfCoreRepository<ProTechtDbContext, Quote, Guid>
    {
        public EfCoreQuoteRepositoryBase(IDbContextProvider<ProTechtDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();

            query = ApplyFilter(query, filterText, amount, vendor, personId);

            var ids = query.Select(x => x.Quote.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<QuoteWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(quote => new QuoteWithNavigationProperties
                {
                    Quote = quote,
                    Person = dbContext.Set<Person>().FirstOrDefault(c => c.Id == quote.PersonId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<QuoteWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, amount, vendor, personId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? QuoteConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<QuoteWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from quote in (await GetDbSetAsync())
                   join person in (await GetDbContextAsync()).Set<Person>() on quote.PersonId equals person.Id into people
                   from person in people.DefaultIfEmpty()
                   select new QuoteWithNavigationProperties
                   {
                       Quote = quote,
                       Person = person
                   };
        }

        protected virtual IQueryable<QuoteWithNavigationProperties> ApplyFilter(
            IQueryable<QuoteWithNavigationProperties> query,
            string? filterText,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Quote.Amount!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(amount), e => e.Quote.Amount.Contains(amount))
                    .WhereIf(vendor.HasValue, e => e.Quote.Vendor == vendor)
                    .WhereIf(personId != null && personId != Guid.Empty, e => e.Person != null && e.Person.Id == personId);
        }

        public virtual async Task<List<Quote>> GetListAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, amount, vendor);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? QuoteConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null,
            Guid? personId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, amount, vendor, personId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Quote> ApplyFilter(
            IQueryable<Quote> query,
            string? filterText = null,
            string? amount = null,
            Vendor? vendor = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Amount!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(amount), e => e.Amount.Contains(amount))
                    .WhereIf(vendor.HasValue, e => e.Vendor == vendor);
        }
    }
}