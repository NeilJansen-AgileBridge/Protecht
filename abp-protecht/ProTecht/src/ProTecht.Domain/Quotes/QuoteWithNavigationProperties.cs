using ProTecht.People;

using System;
using System.Collections.Generic;

namespace ProTecht.Quotes
{
    public abstract class QuoteWithNavigationPropertiesBase
    {
        public Quote Quote { get; set; } = null!;

        public Person Person { get; set; } = null!;
        

        
    }
}