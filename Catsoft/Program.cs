using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using App.cms.Models;
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
        public static async Task Main(string[] args)
        {
            var app = BuildWebHost(args);

            // DoWithScope(app, scoped =>
            // {
            //     scoped.GetRequiredService<DatabaseInitializer>().Init();
            // });
            //
            await DoWithScope(app,async scoped =>
            {
                await scoped.GetRequiredService<TextTranslator>().ForceTranslateLanguage(TextLanguage.Portuguese);
            });

            await app.RunAsync();
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
