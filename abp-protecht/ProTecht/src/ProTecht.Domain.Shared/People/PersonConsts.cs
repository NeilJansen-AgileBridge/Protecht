namespace ProTecht.People
{
    public static class PersonConsts
    {
        private const string DefaultSorting = "{0}PersonId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Person." : string.Empty);
        }

    }
}