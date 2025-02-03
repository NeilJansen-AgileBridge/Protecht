using ProTecht.People;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace ProTecht.Quotes
{
    public abstract class QuoteWithNavigationPropertiesDtoBase
    {
        public QuoteDto Quote { get; set; } = null!;

        public PersonDto Person { get; set; } = null!;

    }
}