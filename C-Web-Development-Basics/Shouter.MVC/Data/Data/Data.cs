namespace Data.Data
{
    public static class Data
    {
        private static ShouterContext context;

        public static ShouterContext Context => context ?? (context = new ShouterContext());
    }
}