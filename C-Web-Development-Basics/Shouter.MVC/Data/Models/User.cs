namespace Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Shouts = new HashSet<Shout>();
            this.Following = new HashSet<User>();
            this.Followers = new HashSet<User>();
            this.UnviewedShouts = new HashSet<Shout>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Shout> Shouts { get; set; }

        public virtual ICollection<User> Following { get; set; }

        public virtual ICollection<User> Followers { get; set; }
        
        public virtual ICollection<Shout> UnviewedShouts { get; set; }
    }
}