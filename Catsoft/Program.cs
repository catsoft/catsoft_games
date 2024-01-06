using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using App.Initialize;
using App.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = BuildWebHost(args);

            InitDatabaseIfNeeded(app);

            app.Run();
        }

        private static void InitDatabaseIfNeeded(IWebHost app)
        {
            using var scope = app.Services.CreateScope();
            
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DatabaseInitializer>();
                context.Init();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during db init.");
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                //.UseKestrel()
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
        }
    }
}
