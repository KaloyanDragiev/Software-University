namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Login
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool isActive { get; set; }
    }
}