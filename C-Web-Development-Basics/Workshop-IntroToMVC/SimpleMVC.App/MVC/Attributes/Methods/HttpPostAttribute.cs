namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool isValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "POST";
        }
    }
}