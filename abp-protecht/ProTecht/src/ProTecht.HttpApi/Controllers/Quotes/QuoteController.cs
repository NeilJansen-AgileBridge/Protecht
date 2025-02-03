using ProTecht.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using ProTecht.Quotes;
using Volo.Abp.Content;
using ProTecht.Shared;

namespace ProTecht.Controllers.Quotes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Quote")]
    [Route("api/app/quotes")]

    public abstract class QuoteControllerBase : AbpController
    {
        protected IQuotesAppService _quotesAppService;

        public QuoteControllerBase(IQuotesAppService quotesAppService)
        {
            _quotesAppService = quotesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<QuoteWithNavigationPropertiesDto>> GetListAsync(GetQuotesInput input)
        {
            return _quotesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<QuoteWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _quotesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<QuoteDto> GetAsync(Guid id)
        {
            return _quotesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("person-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetPersonLookupAsync(LookupRequestDto input)
        {
            return _quotesAppService.GetPersonLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<QuoteDto> CreateAsync(QuoteCreateDto input)
        {
            return _quotesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<QuoteDto> UpdateAsync(Guid id, QuoteUpdateDto input)
        {
            return _quotesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _quotesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(QuoteExcelDownloadDto input)
        {
            return _quotesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _quotesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> quoteIds)
        {
            return _quotesAppService.DeleteByIdsAsync(quoteIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetQuotesInput input)
        {
            return _quotesAppService.DeleteAllAsync(input);
        }
    }
}