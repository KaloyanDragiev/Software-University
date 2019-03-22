namespace IssueTracker.App.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Linq;
    using Models.BindingModels;
    using Service;
    using SimpleHttpServer.Models;
    using SimpleMVC.Interfaces;
    using Security;

    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ErrorViewModel>> Register()
        {
            return this.View(new List<ErrorViewModel>().AsEnumerable());
        }

        [HttpPost]
        public IActionResult<IEnumerable<ErrorViewModel>> Register(RegisterUserBindingModel rubm, HttpResponse response)
        {
            var errors = service.RegisterUser(rubm);
            if (!errors.Any())
            {
                Redirect(response, "/users/login");
                return null;
            }
            return this.View(errors);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public void Login(LoginUserBindingModel lubm, HttpResponse response, HttpSession session)
        {
            if (this.service.TryLogin(lubm, session))
            {
                Redirect(response, "/home/index");
                return;
            }
            Redirect(response, "/users/login");
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            SignInManager.Logout(session, response);
            Redirect(response, "/home/index");
        }
    }
}