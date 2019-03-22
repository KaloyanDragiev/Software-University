namespace SimpleMVC.App.Controllers
{
    using MVC.Contollers;
    using MVC.Attributes.Methods;
    using MVC.Interfaces;
    using BindingModels;
    using Data.Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames = null;
            using (var context = new UsersContext())
            {
                usernames = context.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };
            using (var context = new UsersContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }     
            return View();
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new UsersContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes
                                .Select(x => new NoteViewModel()
                                    {
                                        Title = x.Title,
                                        Content = x.Content
                                    })              
                };
                return View(viewModel);
            }
        }

        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new UsersContext())
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
            return Profile(model.UserId);
        }
    }
}