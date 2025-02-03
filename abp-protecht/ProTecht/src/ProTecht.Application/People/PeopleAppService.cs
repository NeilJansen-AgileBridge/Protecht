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
using ProTecht.People;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using ProTecht.Shared;

namespace ProTecht.People
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ProTechtPermissions.People.Default)]
    public abstract class PeopleAppServiceBase : ProTechtAppService
    {
        protected IDistributedCache<PersonDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IPersonRepository _personRepository;
        protected PersonManager _personManager;

        public PeopleAppServiceBase(IPersonRepository personRepository, PersonManager personManager, IDistributedCache<PersonDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _personRepository = personRepository;
            _personManager = personManager;

        }

        public virtual async Task<PagedResultDto<PersonDto>> GetListAsync(GetPeopleInput input)
        {
            var totalCount = await _personRepository.GetCountAsync(input.FilterText, input.PersonId, input.Name, input.Surname, input.ContactNumber, input.VehicleRegistration, input.VehicleType, input.AgeMin, input.AgeMax);
            var items = await _personRepository.GetListAsync(input.FilterText, input.PersonId, input.Name, input.Surname, input.ContactNumber, input.VehicleRegistration, input.VehicleType, input.AgeMin, input.AgeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PersonDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Person>, List<PersonDto>>(items)
            };
        }

        public virtual async Task<PersonDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Person, PersonDto>(await _personRepository.GetAsync(id));
        }

        [Authorize(ProTechtPermissions.People.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _personRepository.DeleteAsync(id);
        }

        [Authorize(ProTechtPermissions.People.Create)]
        public virtual async Task<PersonDto> CreateAsync(PersonCreateDto input)
        {

            var person = await _personManager.CreateAsync(
            input.PersonId, input.Name, input.Surname, input.Age, input.ContactNumber, input.VehicleRegistration, input.VehicleType
            );

            return ObjectMapper.Map<Person, PersonDto>(person);
        }

        [Authorize(ProTechtPermissions.People.Edit)]
        public virtual async Task<PersonDto> UpdateAsync(Guid id, PersonUpdateDto input)
        {

            var person = await _personManager.UpdateAsync(
            id,
            input.PersonId, input.Name, input.Surname, input.Age, input.ContactNumber, input.VehicleRegistration, input.VehicleType, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Person, PersonDto>(person);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PersonExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _personRepository.GetListAsync(input.FilterText, input.PersonId, input.Name, input.Surname, input.ContactNumber, input.VehicleRegistration, input.VehicleType, input.AgeMin, input.AgeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Person>, List<PersonExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "People.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(ProTechtPermissions.People.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> personIds)
        {
            await _personRepository.DeleteManyAsync(personIds);
        }

        [Authorize(ProTechtPermissions.People.Delete)]
        public virtual async Task DeleteAllAsync(GetPeopleInput input)
        {
            await _personRepository.DeleteAllAsync(input.FilterText, input.PersonId, input.Name, input.Surname, input.ContactNumber, input.VehicleRegistration, input.VehicleType, input.AgeMin, input.AgeMax);
        }
        public virtual async Task<ProTecht.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new PersonDownloadTokenCacheItem { Token = token },
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