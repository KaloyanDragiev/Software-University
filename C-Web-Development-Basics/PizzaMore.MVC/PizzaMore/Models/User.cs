namespace PizzaMore.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.PizzaSuggestions = new HashSet<Pizza>();
            this.PizzaVotedFor = new HashSet<Pizza>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public virtual ICollection<Pizza> PizzaSuggestions { get; set; }

        public virtual ICollection<Pizza> PizzaVotedFor { get; set; }
    }
}