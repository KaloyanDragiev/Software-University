namespace SimpleMVC.App.Controllers
{
    using Attributes.Methods;
    using SimpleMVC.Controllers;
    using Interfaces;
    using System.Collections.Generic;
    using ServiceLayers;
    using ViewModels;
    using Interfaces.Generic;
    using SimpleHttpServer.Models;
    using BindingModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<KnifeViewModel>> Products(string productName)
        {
            // this method does not work if we access only /home/products without productName after it, which is hardcoded in the html
            return View(new RetrieveAllProducts().GetAllKnives(productName));
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(MessageBindingModel model, HttpResponse response)
        {
            if (string.IsNullOrEmpty(model.Subject) || string.IsNullOrEmpty(model.Sender))
            {
                // Do not forget to pass the response from the arguments as parameter
                Redirect(response, "/home/contacts");
                return null;
            }
            new AddMessage().SendMessage(model);

            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult<KnifeViewModel> Buy(int id)
        {
            return View(new GetDesiredKnife().GetKnife(id));
        }

        [HttpPost]
        public IActionResult Buy(PurchaseBindingModel model)
        {           
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Phone) || string.IsNullOrEmpty(model.Address))
            {
                Redirect(new HttpResponse(), "/home/buy");
                return this.View();
            }
            new PurchaseKnife().BuyKnife(model);

            return this.View("Home", "Index");
        }
    }
}