namespace IssueTracker.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Issue> Issues { get; set ; }
    }

    public enum Role
    {
        Regular,
        Administrator
    }
}