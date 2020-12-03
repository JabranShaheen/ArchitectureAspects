using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountForwarderAPI;
using Bootstrapper.IOC;
using AccountForwarderAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace API
{
    public class Program
    {
        public static IUnityContainer unityContainer;
        public static void Main(string[] args)
        {
            unityContainer = new UnityContainer();
            Bootstrap.Register(unityContainer);
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(unityContainer)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
