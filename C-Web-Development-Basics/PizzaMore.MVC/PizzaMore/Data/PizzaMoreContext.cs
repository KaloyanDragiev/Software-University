namespace PizzaMore.Data
{
    using System.Data.Entity;
    using Models;
    using Interfaces;

    public class PizzaMoreContext : DbContext, IDbIdentityContext
    {

        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }
        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
             .HasRequired(pizza => pizza.Owner)
             .WithMany(user => user.PizzaSuggestions)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany<Pizza>(user => user.PizzaVotedFor)
                .WithMany(pizza => pizza.UsersVoted)
                .Map(up =>
                {
                    up.MapLeftKey("UserId");
                    up.MapRightKey("PizzaId");
                    up.ToTable("UsersPizzas");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}