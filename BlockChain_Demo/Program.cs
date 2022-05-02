using BlockChain_Demo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Project...");
            SimulatedNetwork simNet = new SimulatedNetwork();
            Console.WriteLine(simNet.DisplaySimNetworkInfo());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
