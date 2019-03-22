namespace PizzaForum.Data.Data
{
    using System.Data.Entity;
    using Models;

    public class PizzaForumContext : DbContext
    {
        public PizzaForumContext()
            : base("name=PizzaForumContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Reply> Replies { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>()
                .HasRequired(r => r.Topic)
                .WithMany(t => t.Replies)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Topic>()
                .HasRequired(t => t.Category)
                .WithMany(c => c.Topics)
                .WillCascadeOnDelete(true);
        }
    }
}