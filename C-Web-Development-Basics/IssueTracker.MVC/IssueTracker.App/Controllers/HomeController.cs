namespace IssueTracker.App.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using Security;
    using SimpleHttpServer.Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(HttpSession session)
        {
            SignInManager.IsAuthenticated(session.Id);
            return this.View();
        }
    }
}