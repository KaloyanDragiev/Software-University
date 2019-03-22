namespace SoftUniStore.App.Controllers
{
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using Models.BindingModels;
    using Service;
    using Security;

    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/all");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Register(RegisterUserBindingModel rubm, HttpResponse response, HttpSession session)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/all");
                return;
            }

            if (service.RegisterUser(rubm))
            {
                Redirect(response, "/users/login");
                return;
            }
            Redirect(response, "/users/register");
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/all");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Login(HttpSession session, HttpResponse response, LoginUserBindingModel lubm)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/all");
                return;
            }
            if (service.TryLogin(lubm, session))
            {
                Redirect(response, "/home/all");
                return;
            }
            Redirect(response, "/users/login");
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            SignInManager.Logout(session, response);
            Redirect(response, "/home/all");
        }
    }
}