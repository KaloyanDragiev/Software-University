namespace PizzaMore.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using Data;
    using Security;
    using SimpleHttpServer.Models;

    public class HomeController : Controller
    {
        private SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Index(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/indexlogged");
                return null;
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Indexlogged()
        {
            return this.View();
        }
    }
}