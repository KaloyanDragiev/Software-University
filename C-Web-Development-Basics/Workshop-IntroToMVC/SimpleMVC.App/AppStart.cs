namespace SimpleMVC.App
{
    using SimpleHttpServer;
    using MVC;

    public class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}