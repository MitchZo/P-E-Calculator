using KTC_Scraper.Contexts;
using KTC_Scraper.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFFBImport;
using TFFBImport.Controllers;

namespace KTC_Scraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices((_, services) =>
                    services.AddSingleton<IConnectionString,ConnectionString>()
                            .AddSingleton<IScraperService,ScraperService>()
                            .AddSingleton<IKtcContext,KtcContext>()
                            .AddSingleton<IImportController,ImportController>());
        }
    }
