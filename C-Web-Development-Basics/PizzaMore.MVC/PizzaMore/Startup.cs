namespace PizzaMore
{
    using SimpleHttpServer;
    using SimpleMVC;

    class Startup
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMore");
        }
    }
}