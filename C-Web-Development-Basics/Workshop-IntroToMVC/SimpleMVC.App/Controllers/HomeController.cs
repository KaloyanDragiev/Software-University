namespace SimpleMVC.App.Controllers
{
    using MVC.Contollers;
    using MVC.Interfaces;
    using MVC.Attributes.Methods;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}