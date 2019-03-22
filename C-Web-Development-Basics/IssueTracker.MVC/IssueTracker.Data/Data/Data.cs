namespace IssueTracker.Data.Data
{
    using Contracts;

    public static class Data
    {
        private static IUnitOfWork context;

        public static IUnitOfWork Context => context ?? (context = new UnitOfWork());
    }
}