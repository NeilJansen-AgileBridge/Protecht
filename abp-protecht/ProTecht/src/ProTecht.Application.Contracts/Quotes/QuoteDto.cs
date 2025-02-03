using ProTecht.Enum;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace ProTecht.Quotes
{
    public abstract class QuoteDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? Amount { get; set; }
        public Vendor Vendor { get; set; }
        public Guid? PersonId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}