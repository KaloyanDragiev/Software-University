namespace PizzaMore.Controllers
{
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using Data;
    using Security;
    using SimpleMVC.Controllers;
    using ServiceLayers;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using BindingModels;
    using SimpleMVC.Interfaces;
    using System.Collections.Generic;

    public class MenuController : Controller
    {
        private SignInManager signInManager;

        public MenuController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult<IEnumerable<PizzaViewModel>> Index(HttpSession session, HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return View(new DisplayAllPizzas().GetPizzas(session, "noSorting"));
            }

            Redirect(response, "/users/signin");
            return null;
        }

        [HttpPost]
        public IActionResult Index(PizzaVoteBindingModel model, HttpResponse response, HttpSession session)
        {
            new VoteForPizza().Vote(model.Pizzaid, model.Pizzavote, session);

            Redirect(response, "/menu/index");
            return null;
        }

        [HttpGet]
        public IActionResult<PizzaSuggestionsViewModel> Suggestions(HttpSession session, HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return View(new DisplayUserSuggestedPizzas().GetPizzas(session));
            }

            Redirect(response, "/users/signin");
            return null;
        }

        [HttpPost]
        public IActionResult<PizzaSuggestionsViewModel> Suggestions(HttpSession session, HttpResponse response, PizzaDeleteBindingModel model)
        {
            new RemovePizza().Remove(model.Pizzaid);

            Redirect(response, "/menu/suggestions");
            return null;
        }

        [HttpGet]
        public IActionResult Add(HttpResponse response, HttpSession session)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/signin");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(PizzaBindingModel model, HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/signin");
                return null;
            }
            new AddPizza().Add(session, model);
            return this.View();
        }

        [HttpGet]
        public IActionResult<PizzaDetailsViewModel> Details(int pizzaid, HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/signin");
                return null;
            }
            return View(new ShowPizzaDetails().Show(pizzaid));
        }

        [HttpGet]
        public IActionResult<IEnumerable<PizzaViewModel>> Sorted(HttpSession session, HttpResponse response)
        {
            if (signInManager.IsAuthenticated(session))
            {
                return View(new DisplayAllPizzas().GetPizzas(session, "defaultSort"));
            }

            Redirect(response, "/users/signin");
            return null;
        }

        [HttpPost]
        public IActionResult<IEnumerable<PizzaViewModel>> Sorted(SortingBindingModel model, HttpResponse response, HttpSession session)
        {
            string sortingMethod = model.FirstCriteria + "_" + model.SecondCriteria;
            return View(new DisplayAllPizzas().GetPizzas(session, sortingMethod));
        }
    }
}