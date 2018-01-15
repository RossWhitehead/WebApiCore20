using System;
using Microsoft.AspNetCore.Hosting;

namespace IdentityServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IdentityServer";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
