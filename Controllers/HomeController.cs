using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace KTC_Scraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScraperService _scraperService;

        public HomeController(ILogger<HomeController> logger, IScraperService scraperService)
        {
            _logger = logger;
            _scraperService = scraperService;
        }

        public IActionResult Index()
        {
            return Redirect("Scraper/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
