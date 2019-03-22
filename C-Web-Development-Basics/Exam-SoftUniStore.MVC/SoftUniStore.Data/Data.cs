namespace SoftUniStore.Data
{
    using Contracts;

    public class Data
    {
        private static IUnitOfWork context;

        public static IUnitOfWork Context => context ?? (context = new UnitOfWork());
    }
}