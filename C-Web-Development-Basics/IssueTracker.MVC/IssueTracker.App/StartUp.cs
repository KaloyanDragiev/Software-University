namespace IssueTracker.App
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class StartUp
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "IssueTracker.App");
        }
    }
}