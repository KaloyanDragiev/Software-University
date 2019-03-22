namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleHttpServer.Models;
    using BindingModels;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using MVC.Security;
    using ViewModels;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new NotesAppContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult<UserViewModel> Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Passsword = model.Password
            };
            using (var context = new NotesAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            var viewModel = new UserViewModel()
            {
                Username = model.Username
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllUsersViewModel>> All(HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                List<AllUsersViewModel> list = new List<AllUsersViewModel>();
                return Redirect(list.AsEnumerable() , "/users/login");
            }

            List<User> users = null;

            using (var contex = new NotesAppContext())
            {
                users = contex.Users.ToList();
            }

            var viewModel = new List<AllUsersViewModel>();
            foreach (var user in users)
            {
                viewModel.Add(new AllUsersViewModel()
                {
                    Username = user.Username,
                    Id = user.Id
                });
            }

            return this.View(viewModel.AsEnumerable());
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes.Select(x => new NoteViewModel()
                    {
                        Title = x.Title,
                        Content = x.Content
                    })
                };
                return this.View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };
                user.Notes.Add(note);
                context.SaveChanges();
            }
            return this.Profile(model.UserId);
        }

        [HttpGet]
        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session)
        {
            string username = model.Username;
            string password = model.Password;
            string sessionId = session.Id;

            using (var context = new NotesAppContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user.Passsword == password)
                {
                    Login login = new Login
                    {
                        isActive = true,
                        SessionId = sessionId,
                        User = user
                    };
                    context.Logins.Add(login);
                    context.SaveChanges();
                    if (signInManager.IsAuthenticated(session))
                    {
                        List<AllUsersViewModel> list = new List<AllUsersViewModel>();
                        return Redirect("/home/index");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session)
        {
            if (signInManager.IsAuthenticated(session))
            {
                using (var context = new NotesAppContext())
                {
                    Login login = context.Logins.FirstOrDefault(l => l.SessionId == session.Id);
                    context.Logins.Remove(login);       // Or set login.IsActive = false;
                    context.SaveChanges();
                }
                return Redirect("/home/index");
            }
            return View();
        }
    }
}
