namespace SimpleHttpServer
{
    using System.Net;
    using System.Threading;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using Models;

    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor(routes);
            this.isActive = true;
        }

        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public HttpProcessor Processor { get; private set; }

        public bool isActive { get; private set; }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            Listener.Start();

            while (true)
            {
                TcpClient client = this.Listener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    this.Processor.HandleClient(client);
                } );
                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}