namespace Shouter
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class Startup
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "Shouter");
        }
    }
}