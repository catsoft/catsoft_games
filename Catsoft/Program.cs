using System;
using System.IO;
using System.Threading.Tasks;
using App.cms.Models;
using App.Initialize;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = BuildWebHost(args);

            // DoWithScope(app, scoped =>
            // {
                // scoped.GetRequiredService<DatabaseCleaner>().CleanTX();
            // });
            
            // DoWithScope(app, scoped =>
            // {
            //     scoped.GetRequiredService<DatabaseInitializer>().Init();
            // });
            //
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            {
                await DoWithScope(app,async scoped =>
                {
                    await scoped.GetRequiredService<TextTranslator>().TranslateNotTranslated();
                });
            }

            await app.RunAsync();
        }

        private static async Task DoWithScope(IWebHost app, Action<IServiceProvider> action)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                action(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetService<ILogger<Program>>();
                Console.WriteLine(ex);
                logger.LogError(ex, "An error occurred during db init.");
            }
        }
        
        private static async Task DoWithScope(IWebHost app, Func<IServiceProvider, Task> action)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                await action(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetService<ILogger<Program>>();
                Console.WriteLine(ex);
                logger.LogError(ex, "An error occurred during db init.");
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                // .UseKestrel()
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
        }
    }
}