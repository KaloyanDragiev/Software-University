namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifiedName)
        {
            this.Action = (IRenderable) Activator.CreateInstance(Type.GetType(viewFullQualifiedName));
        }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public IRenderable Action { get; set; }
    }
}