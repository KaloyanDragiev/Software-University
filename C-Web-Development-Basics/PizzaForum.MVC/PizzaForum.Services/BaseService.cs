namespace PizzaForum.Services
{
    using Data.Data;

    public abstract class BaseService
    {
        protected PizzaForumContext Context { get; }

        public BaseService()
        {
            this.Context = Data.Context;
        }
    }
}