using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using ProTecht.People;
using Volo.Abp.Content;
using ProTecht.Shared;

namespace ProTecht.Controllers.People
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Person")]
    [Route("api/app/people")]

    public abstract class PersonControllerBase : AbpController
    {
        protected IPeopleAppService _peopleAppService;

        public PersonControllerBase(IPeopleAppService peopleAppService)
        {
            _peopleAppService = peopleAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PersonDto>> GetListAsync(GetPeopleInput input)
        {
            return _peopleAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PersonDto> GetAsync(Guid id)
        {
            return _peopleAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<PersonDto> CreateAsync(PersonCreateDto input)
        {
            return _peopleAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PersonDto> UpdateAsync(Guid id, PersonUpdateDto input)
        {
            return _peopleAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _peopleAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(PersonExcelDownloadDto input)
        {
            return _peopleAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _peopleAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> personIds)
        {
            return _peopleAppService.DeleteByIdsAsync(personIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetPeopleInput input)
        {
            return _peopleAppService.DeleteAllAsync(input);
        }
    }
}