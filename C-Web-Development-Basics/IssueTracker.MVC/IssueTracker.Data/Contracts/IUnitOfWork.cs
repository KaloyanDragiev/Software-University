namespace IssueTracker.Data.Contracts
{
    using Models;

    public interface IUnitOfWork
    {
        IRepository<Session> Sessions { get; }

        IRepository<User> Users { get; }

        IRepository<Issue> Issues { get; }

        int SaveChanges();
    }
}