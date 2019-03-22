namespace Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Shout
    {

        public Shout()
        {
            this.UnseenBy = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? PublishTime { get; set; }

        public int HourDuration { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> UnseenBy { get; set; }
    }
}