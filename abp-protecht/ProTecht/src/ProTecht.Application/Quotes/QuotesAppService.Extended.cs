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
    public class QuotesAppService : QuotesAppServiceBase, IQuotesAppService
    {
        //<suite-custom-code-autogenerated>
        public QuotesAppService(IQuoteRepository quoteRepository, QuoteManager quoteManager, IDistributedCache<QuoteDownloadTokenCacheItem, string> downloadTokenCache, IRepository<ProTecht.People.Person, Guid> personRepository)
            : base(quoteRepository, quoteManager, downloadTokenCache, personRepository)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}