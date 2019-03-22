namespace PizzaForum.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        public Topic()
        {
            this.Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? PublishDate { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual Category Category { get; set; }
    }
}