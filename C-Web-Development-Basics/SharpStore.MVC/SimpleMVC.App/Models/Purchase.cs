namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Purchase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DeliveryType DeliveryType { get; set; } 

        public int KnifeId { get; set; }
        [ForeignKey("KnifeId")]
        public virtual Knife Knife { get; set; }
    }

    public enum DeliveryType
    {
        Express,
        Economy
    }
}