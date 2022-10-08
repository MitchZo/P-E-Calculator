using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TFFBImport;
using TFFBImport.Controllers;

namespace KTC_Scraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScraperService _scraperService;
        private readonly IImportController _importController;

        public HomeController(ILogger<HomeController> logger, ScraperService scraperService, ImportController importController)
        {
            _logger = logger;
            _scraperService = scraperService;
            _importController = importController;
        }

        public IActionResult Index()
        {
            return Redirect("Scraper/Index");
        }

        public void CompareTFFB()
        {
            _importController.ProcessCsv();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
