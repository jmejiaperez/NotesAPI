using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace NotesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(x =>
                {
                    x.AddServerHeader = false;
                    x.Listen(IPAddress.Any, 5000,
                        listenOptions => { listenOptions.Protocols = HttpProtocols.Http1AndHttp2; });
                })
                .UseStartup<Startup>();
    }
}
