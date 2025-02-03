namespace ProTecht.Quotes
{
    public static class QuoteConsts
    {
        private const string DefaultSorting = "{0}Amount asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Quote." : string.Empty);
        }

    }
}