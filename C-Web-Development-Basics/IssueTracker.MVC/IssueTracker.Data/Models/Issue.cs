namespace IssueTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Issue
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public DateTime? PublishDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        New,
        Solved
    }
}