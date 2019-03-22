namespace PizzaMore.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using BindingModels;
    using ServiceLayers;
    using SimpleHttpServer.Models;
    using Data;
    using Security;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(UserBindingModel model, HttpResponse response)
        {
            new RegisterNewUser().RegUser(model);

            // should redirect because we are using a post method
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(UserBindingModel model, HttpSession session, HttpResponse response)
        {
            new UserSigningIn().TrySigningIn(model, session);
            if (signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/indexlogged");
                return null;
            }

            // should redirect because we are using a post method
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            signInManager.Logout(session, response);
            Redirect(response, "/home/index");
            return null;
        }
    }
}