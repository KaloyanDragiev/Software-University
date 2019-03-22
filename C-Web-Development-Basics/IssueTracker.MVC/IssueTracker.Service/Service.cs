namespace IssueTracker.Service
{
    using Data.Contracts;
    using Data.Data;

    public abstract class Service
    {
        protected IUnitOfWork Context { get; }

        protected Service()
        {
            this.Context = Data.Context;
        }
    }
}