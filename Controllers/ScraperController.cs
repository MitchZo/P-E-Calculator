using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TFFBImport;
using TFFBImport.Controllers;

namespace KTC_Scraper.Controllers
{
    public class ScraperController : Controller
    {
        private readonly IScraperService _scraperService;
        private readonly IImportController _importController;
        private readonly IKtcContext _ktcContext;

        public ScraperController(ScraperService scraperService, ImportController importController, IKtcContext ktcContext)
        {
            _scraperService = scraperService;
            _importController = importController;
            _ktcContext = ktcContext;
        }

        public async Task<IActionResult> Index()
        {
            List<Player> playerList = await _scraperService.GetCurrentPlayers();
            return View(playerList);
        }

        [HttpPost]
        public async Task<IActionResult> ProRanksCsv(IFormFile csv)
        {
            List<Player> playerList = await _scraperService.GetCurrentPlayers();
            return View(playerList);
        }
    }
}
