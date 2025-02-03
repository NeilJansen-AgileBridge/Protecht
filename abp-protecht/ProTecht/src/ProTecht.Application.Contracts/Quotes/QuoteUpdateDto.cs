using ProTecht.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ProTecht.Quotes
{
    public abstract class QuoteUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Amount { get; set; }
        public Vendor Vendor { get; set; }
        public Guid? PersonId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}