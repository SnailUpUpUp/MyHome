﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.DependencyInjection;
using MyHome.Models;

namespace MyHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            
            var host=CreateWebHostBuilder(args).Build();

            using(var scope= host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context=services.GetRequiredService<HomeContext>();
                    context.Database.EnsureCreated();
                }
                catch(Exception ex)
                {
                    var logger=services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex,"An error occurred creating the DB.");
                }
            }

            host.Run();

            // Publish:
            // dotnet publish -c release -f netcoreapp2.1
            // dotnet publish -c release -f netcoreapp2.1 -o E:\USR\Projects\GitHub\MyHome\MyHome_publish  --force
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
