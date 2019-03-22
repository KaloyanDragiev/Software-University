using System.Collections.Generic;
using PizzaForum.Data.Models;
using PizzaForum.Models.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.App.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using Models.BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using Security;

    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Register(RegisterUserBindingModel rubm, HttpResponse response)
        {
            if (service.RegisterUser(rubm))
            {
                Redirect(response, "/forum/login");
                return;
            }
            Redirect(response, "/forum/register");
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public void Login(LoginBindingModel lbm, HttpSession session, HttpResponse response)
        {
            if (service.TryLogin(lbm, session))
            {
                Redirect(response, "/home/topics");
                return;
            }
            Redirect(response, "/forum/login");
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            SignInManager.Logout(session, response);
            Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProfileTopicsViewModel>> Profile(HttpSession session, HttpResponse response,
            int id)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/forum/login");
                return null;
            }
            User user = SignInManager.GetAuthenticatedUser(session.Id);
            if (user.Id == id)
            {
                return this.View(service.GetProfileMine(user.Id));
            }
            else
            {
                return this.View(service.GetProfileOther(id));
            }
        }
    }
}