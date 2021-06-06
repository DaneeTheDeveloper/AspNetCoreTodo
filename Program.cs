using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace AspNetCoreTodo
{
    public class Program
    {
       public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            InitializeDatabase(host);
            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void InitializeDatabase(IWebHost host) 
        {
            using (var scope = host.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.InitializeAsync(services).Wait();
                }

                catch (Exception ex) 
                {
                    var logger = services 
                    .GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error occurred seeding the DB."); 

                }

            } 

        }

    }
    
}
