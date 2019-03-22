namespace SoftUniStore.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoftUniStoreContext context;
        private IRepository<Session> sessions;
        private IRepository<User> users;
        private IRepository<Game> games;

        public UnitOfWork()
        {
            this.context = new SoftUniStoreContext();
        }

        public IRepository<Session> Sessions
            => this.sessions ?? (this.sessions = new Repository<Session>(this.context.Sessions));

        public IRepository<User> Users => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public IRepository<Game> Games => this.games ?? (this.games = new Repository<Game>(this.context.Games));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}