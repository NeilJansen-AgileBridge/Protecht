using ProTecht.Shared;
using ProTecht.People;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using ProTecht.Permissions;
using ProTecht.Quotes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using ProTecht.Shared;

namespace ProTecht.Quotes
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ProTechtPermissions.Quotes.Default)]
    public abstract class QuotesAppServiceBase : ProTechtAppService
    {
        protected IDistributedCache<QuoteDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IQuoteRepository _quoteRepository;
        protected QuoteManager _quoteManager;

        protected IRepository<ProTecht.People.Person, Guid> _personRepository;

        public QuotesAppServiceBase(IQuoteRepository quoteRepository, QuoteManager quoteManager, IDistributedCache<QuoteDownloadTokenCacheItem, string> downloadTokenCache, IRepository<ProTecht.People.Person, Guid> personRepository)
        {
            _downloadTokenCache = downloadTokenCache;
            _quoteRepository = quoteRepository;
            _quoteManager = quoteManager; _personRepository = personRepository;

        }

        public virtual async Task<PagedResultDto<QuoteWithNavigationPropertiesDto>> GetListAsync(GetQuotesInput input)
        {
            var totalCount = await _quoteRepository.GetCountAsync(input.FilterText, input.Amount, input.Vendor, input.PersonId);
            var items = await _quoteRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Amount, input.Vendor, input.PersonId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<QuoteWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<QuoteWithNavigationProperties>, List<QuoteWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<QuoteWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<QuoteWithNavigationProperties, QuoteWithNavigationPropertiesDto>
                (await _quoteRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<QuoteDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Quote, QuoteDto>(await _quoteRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPersonLookupAsync(LookupRequestDto input)
        {
            var query = (await _personRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<ProTecht.People.Person>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ProTecht.People.Person>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(ProTechtPermissions.Quotes.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _quoteRepository.DeleteAsync(id);
        }

        [Authorize(ProTechtPermissions.Quotes.Create)]
        public virtual async Task<QuoteDto> CreateAsync(QuoteCreateDto input)
        {

            var quote = await _quoteManager.CreateAsync(
            input.PersonId, input.Vendor, input.Amount
            );

            return ObjectMapper.Map<Quote, QuoteDto>(quote);
        }

        [Authorize(ProTechtPermissions.Quotes.Edit)]
        public virtual async Task<QuoteDto> UpdateAsync(Guid id, QuoteUpdateDto input)
        {

            var quote = await _quoteManager.UpdateAsync(
            id,
            input.PersonId, input.Vendor, input.Amount, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Quote, QuoteDto>(quote);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(QuoteExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var quotes = await _quoteRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Amount, input.Vendor, input.PersonId);
            var items = quotes.Select(item => new
            {
                Amount = item.Quote.Amount,
                Vendor = item.Quote.Vendor,

                Person = item.Person?.Name,

            });

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Quotes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(ProTechtPermissions.Quotes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> quoteIds)
        {
            await _quoteRepository.DeleteManyAsync(quoteIds);
        }

        [Authorize(ProTechtPermissions.Quotes.Delete)]
        public virtual async Task DeleteAllAsync(GetQuotesInput input)
        {
            await _quoteRepository.DeleteAllAsync(input.FilterText, input.Amount, input.Vendor, input.PersonId);
        }
        public virtual async Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new QuoteDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new ProTecht.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}