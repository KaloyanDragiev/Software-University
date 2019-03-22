namespace Shouter.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Controllers;
    using Services;
    using Models.BindingModels;
    using SimpleHttpServer.Models;
    using Security;

    public class UsersController : Controller
    {
        private UsersService service;
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager();
            this.service = new UsersService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpResponse response)
        {
            if (service.RegisterUser(rubm))
            {
                Redirect(response, "/users/login");
                return null;
            }

            Redirect(response, "/users/register");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel lbm, HttpResponse response, HttpSession session)
        {
            if (service.LoginUser(lbm, session))
            {
                Redirect(response, "/home/feedsigned");
                return null;
            }
            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            signInManager.Logout(session, response);
            Redirect(response, "/home/feed");
        }
    }
}