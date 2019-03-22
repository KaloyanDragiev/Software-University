using SimpleHttpServer;

namespace SimpleMVC.App
{
    class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SimpleMVC.App");
        }
    }
}