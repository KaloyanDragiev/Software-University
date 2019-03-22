using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Data
{
    using Models;
    using System.Data.Entity;

    public class NotesAppContext : DbContext, IDbIdentityContext
    {
        public NotesAppContext()
            : base("NotesAppContext")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual DbSet<Note> Notes { get; set; }
    }
}