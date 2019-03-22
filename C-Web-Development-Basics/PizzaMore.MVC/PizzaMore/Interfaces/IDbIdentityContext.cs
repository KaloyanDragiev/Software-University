namespace PizzaMore.Interfaces
{
    using System.Data.Entity;
    using Models;

    public interface IDbIdentityContext
    {
        DbSet<Pizza> Pizzas { get; }
        DbSet<Session> Sessions { get; }
        DbSet<User> Users { get; }
        void SaveChanges();
    }
}