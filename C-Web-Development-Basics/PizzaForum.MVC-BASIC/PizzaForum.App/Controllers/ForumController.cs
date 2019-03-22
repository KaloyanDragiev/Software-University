namespace PizzaForum.App.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class ForumController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }
    }
}