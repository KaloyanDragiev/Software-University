namespace PizzaForum.App.Controllers
{
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using Data.Models;
    using System.Collections.Generic;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using Services;
    using SimpleMVC.Interfaces;
    using Models.BindingModels;

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<CategoryViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (InvalidAdmin(session, response))
                return null;

            return this.View(service.GetAdminCategories());
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (InvalidAdmin(session, response))
                return null;

            return this.View();
        }

        [HttpPost]
        public void New(HttpSession session, HttpResponse response, EditCategoryBindingModel ncbm)
        {
            if (InvalidAdmin(session, response))
                return;

            service.AddNewCategory(ncbm);
            Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpSession session, HttpResponse response, int id)
        {
            if (InvalidAdmin(session, response))
                return;

            service.DeleteCategory(id);
            Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<CategoryViewModel> Edit(HttpSession session, HttpResponse response, int id)
        {
            if (InvalidAdmin(session, response))
                return null;

            return this.View(service.ShowCurrentCategoryName(id));
        }

        [HttpPost]
        public void Edit(HttpSession session, HttpResponse response, EditCategoryBindingModel ecbm)
        {
            if (InvalidAdmin(session, response))
                return;

            service.EditCategoryName(ecbm);
            Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpResponse response, HttpSession session,
            string categoryName)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/forum/login");
                return null;
            }
            IEnumerable<TopicViewModel> topicVMs = service.ShowCategoryTopics(categoryName);
            return this.View(topicVMs);
        }

        private bool InvalidAdmin(HttpSession session, HttpResponse response)
        {
            if (!SignInManager.IsAuthenticated(session.Id))
            {
                Redirect(response, "/forum/login");
                return true;
            }
            User currentUser = SignInManager.GetAuthenticatedUser(session.Id);
            if (!currentUser.IsAdmin)
            {
                Redirect(response, "/home/topics");
                return true;
            }
            return false;
        }
    }
}