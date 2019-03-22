namespace SimpleMVC.App.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}