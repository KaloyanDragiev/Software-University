namespace PizzaMore.Data
{
    using Models;
    using System.Data.Entity;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}