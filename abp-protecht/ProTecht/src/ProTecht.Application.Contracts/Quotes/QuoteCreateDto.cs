using ProTecht.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProTecht.Quotes
{
    public abstract class QuoteCreateDtoBase
    {
        public string? Amount { get; set; }
        public Vendor Vendor { get; set; }
        public Guid? PersonId { get; set; }
    }
}