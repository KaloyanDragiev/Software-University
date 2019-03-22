namespace IssueTracker.Data.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IssueTrackerContext context;
        private IRepository<Session> sessions;
        private IRepository<User> users;
        private IRepository<Issue> issues;

        public UnitOfWork()
        {
            this.context = new IssueTrackerContext();
        }

        public IRepository<Session> Sessions
            => this.sessions ?? (this.sessions = new Repository<Session>(this.context.Sessions));

        public IRepository<User> Users => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public IRepository<Issue> Issues => this.issues ?? (this.issues = new Repository<Issue>(this.context.Issues));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}