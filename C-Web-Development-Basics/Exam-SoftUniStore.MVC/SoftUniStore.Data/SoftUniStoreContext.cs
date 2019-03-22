namespace SoftUniStore.Data
{
    using System.Data.Entity;
    using Models;

    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("name=SoftUniStoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Games)
                .WithMany(g => g.Owners)
                .Map(ug =>
                    ug.MapLeftKey("OwnerId")
                        .MapRightKey("GameId")
                        .ToTable("UsersGames"));
        }
    }
}