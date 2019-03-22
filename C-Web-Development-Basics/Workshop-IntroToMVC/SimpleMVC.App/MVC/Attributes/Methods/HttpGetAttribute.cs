namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool isValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "GET";
        }
    }
}