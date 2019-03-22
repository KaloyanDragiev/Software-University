namespace SimpleMVC.App.Data
{
    using System.Data.Entity;
    using Models;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }
        public virtual DbSet<Knife> Knives { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }
    }
}