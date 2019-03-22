namespace SimpleMVC.App.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Notes = new List<Note>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}