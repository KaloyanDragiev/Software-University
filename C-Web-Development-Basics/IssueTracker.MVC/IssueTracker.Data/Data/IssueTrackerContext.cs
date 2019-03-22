namespace IssueTracker.Data.Data
{
    using System.Data.Entity;
    using Models;

    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext()
            : base("name=IssueTrackerContext")
        {
        }
         public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Issue> Issues { get; set; }
    }
}