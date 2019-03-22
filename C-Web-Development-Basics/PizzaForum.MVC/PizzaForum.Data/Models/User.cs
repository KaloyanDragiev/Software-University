namespace PizzaForum.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
            this.Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}