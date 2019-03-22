namespace SoftUniStore.Models.BindingModels
{
    public class RegisterUserBindingModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}