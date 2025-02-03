using System;

namespace ProTecht.Quotes;

public abstract class QuoteDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}