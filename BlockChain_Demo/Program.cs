using BlockChain_Demo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * blockchain waits until miner finds nonce
 * add block creates new block pass params
 * 
 * 
 * 
 * 
 * 
 * 
 */ 

namespace BlockChain_Demo
{
    public class Program
    {
        // Source https://dev.to/amir_ashy/simplest-blockchain-in-c-1f70
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Project...");
            SimulatedNetwork simNet = new SimulatedNetwork();
            Console.WriteLine(simNet.DisplaySimNetworkInfo());
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
