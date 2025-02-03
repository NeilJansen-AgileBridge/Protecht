using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using ProTecht.People;

namespace ProTecht.Controllers.People
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Person")]
    [Route("api/app/people")]

    public class PersonController : PersonControllerBase, IPeopleAppService
    {
        public PersonController(IPeopleAppService peopleAppService) : base(peopleAppService)
        {
        }
    }
}