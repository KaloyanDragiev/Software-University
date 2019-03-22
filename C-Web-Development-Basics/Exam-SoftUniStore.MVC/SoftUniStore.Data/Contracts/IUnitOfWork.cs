namespace SoftUniStore.Data.Contracts
{
    using Models;

    public interface IUnitOfWork
    {
        IRepository<Session> Sessions { get; }

        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}