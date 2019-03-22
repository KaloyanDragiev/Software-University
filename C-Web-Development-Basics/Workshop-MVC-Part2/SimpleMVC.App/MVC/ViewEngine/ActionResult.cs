using SimpleMVC.App.MVC.Interfaces;
using System;

namespace SimpleMVC.App.MVC.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public ActionResult(string viewFullQualifedName, string location) : this(viewFullQualifedName)
        {
            this.Location = location;
        }
        public IRenderable Action { get; set; }

        public string Location { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}