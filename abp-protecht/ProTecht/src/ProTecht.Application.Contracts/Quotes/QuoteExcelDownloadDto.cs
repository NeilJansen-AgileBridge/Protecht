using ProTecht.Enum;
using Volo.Abp.Application.Dtos;
using System;

namespace ProTecht.Quotes
{
    public abstract class QuoteExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Amount { get; set; }
        public Vendor? Vendor { get; set; }
        public Guid? PersonId { get; set; }

        public QuoteExcelDownloadDtoBase()
        {

        }
    }
}