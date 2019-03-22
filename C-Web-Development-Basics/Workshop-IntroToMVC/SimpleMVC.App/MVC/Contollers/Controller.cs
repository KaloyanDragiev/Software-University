namespace SimpleMVC.App.MVC.Contollers
{
    using Interfaces.Generic;
    using ViewEngine.Generic;
    using System.Runtime.CompilerServices;
    using Interfaces;
    using ViewEngine;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);
            
            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(string controller, string action, T model)
        {
            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}