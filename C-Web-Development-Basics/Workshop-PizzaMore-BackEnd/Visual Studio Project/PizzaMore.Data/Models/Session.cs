namespace PizzaMore.Data.Models
{
    public class Session
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}\t{this.User.Id}";
        }
    }
}