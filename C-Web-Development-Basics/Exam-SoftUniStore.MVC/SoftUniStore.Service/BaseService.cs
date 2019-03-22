namespace SoftUniStore.Service
{
    using Data.Contracts;
    using Data;

    public abstract class BaseService
    {
        protected IUnitOfWork Context { get; }

        protected BaseService()
        {
            this.Context = Data.Context;
        }
    }
}