namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using System;
    using Interfaces.Generic;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>) Activator.CreateInstance(Type.GetType(viewFullQualifiedName));
            this.Action.Model = model;
        }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public IRenderable<T> Action { get; set; }
    }
}