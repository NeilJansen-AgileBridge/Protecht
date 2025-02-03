using ProTecht.Enum;
using System;

namespace ProTecht.Quotes
{
    public abstract class QuoteExcelDtoBase
    {
        public string? Amount { get; set; }
        public Vendor Vendor { get; set; }
    }
}