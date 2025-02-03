using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using ProTecht.Quotes;

namespace ProTecht.Controllers.Quotes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Quote")]
    [Route("api/app/quotes")]

    public class QuoteController : QuoteControllerBase, IQuotesAppService
    {
        public QuoteController(IQuotesAppService quotesAppService) : base(quotesAppService)
        {
        }
    }
}