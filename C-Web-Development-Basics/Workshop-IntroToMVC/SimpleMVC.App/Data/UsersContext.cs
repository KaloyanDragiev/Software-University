namespace SimpleMVC.App.Data
{
    using System.Data.Entity;
    using Models;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
    }
}