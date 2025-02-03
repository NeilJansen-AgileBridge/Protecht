using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using ProTecht.Shared;

namespace ProTecht.People
{
    public partial interface IPeopleAppService : IApplicationService
    {

        Task<PagedResultDto<PersonDto>> GetListAsync(GetPeopleInput input);

        Task<PersonDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PersonDto> CreateAsync(PersonCreateDto input);

        Task<PersonDto> UpdateAsync(Guid id, PersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PersonExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> personIds);

        Task DeleteAllAsync(GetPeopleInput input);
        Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}