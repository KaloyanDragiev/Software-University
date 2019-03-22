namespace Models.ViewModels
{
    public class NotificationViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public override string ToString()
        {
            return $"<li><h4><strong><a href=\"/followers/profile?id={this.Id}\">{this.Username}</a></strong> posted a shout</h4></li>";
        }
    }
}