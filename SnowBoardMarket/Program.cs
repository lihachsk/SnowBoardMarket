using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SnowBoardMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000);  // http:localhost:5000
                    options.Listen(IPAddress.Any, 80);         // http:*:80
                    options.Listen(IPAddress.Loopback, 443, listenOptions =>
                    {
                        listenOptions.UseHttps("cert.pfx", "159753");
                    });
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
