using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            InitilaizeBooks(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        /// <summary>
        /// When app was started, book data load.
        /// </summary>
        /// <param name="host"></param>
        private static void InitilaizeBooks(IHost host)
        {
            // Find the service layer within our scope.
            using ( var scope = host.Services.CreateScope() )
            {
                // Get the instance of BoardGamesDBContext in our services layer
                var services = scope.ServiceProvider;

                // Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
            }
        }
    }
}
