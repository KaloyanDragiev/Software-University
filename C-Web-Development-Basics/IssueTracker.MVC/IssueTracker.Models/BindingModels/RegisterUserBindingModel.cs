namespace IssueTracker.Models.BindingModels
{
    public class RegisterUserBindingModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string FullName { get; set; }
    }
}