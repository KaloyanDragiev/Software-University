namespace Data.Data
{
    using Models;
    using System.Data.Entity;

    public class ShouterContext : DbContext
    {
        public ShouterContext()
            : base("name=ShouterContext")
        {
        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Shout> Shouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(userFollowing => userFollowing
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowingId")
                    .ToTable("UsersFollowings"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(userFollowing => userFollowing
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowårId")
                    .ToTable("UsersFollowårs"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.UnviewedShouts)
                .WithMany(s => s.UnseenBy)
                .Map(userShout => userShout
                    .MapLeftKey("UserId")
                    .MapRightKey("ShoutId")
                    .ToTable("UsersShouts"));

            base.OnModelCreating(modelBuilder);
        }
    }
}