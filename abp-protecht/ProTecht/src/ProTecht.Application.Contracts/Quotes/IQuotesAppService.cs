using ProTecht.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using ProTecht.Shared;

namespace ProTecht.Quotes
{
    public partial interface IQuotesAppService : IApplicationService
    {

        Task<PagedResultDto<QuoteWithNavigationPropertiesDto>> GetListAsync(GetQuotesInput input);

        Task<QuoteWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<QuoteDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPersonLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<QuoteDto> CreateAsync(QuoteCreateDto input);

        Task<QuoteDto> UpdateAsync(Guid id, QuoteUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(QuoteExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> quoteIds);

        Task DeleteAllAsync(GetQuotesInput input);
        Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}