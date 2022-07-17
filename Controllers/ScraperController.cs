using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KTC_Scraper.Controllers
{
    public class ScraperController : Controller
    {
        private readonly IScraperService _scraperService;

        public ScraperController(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        public IActionResult Index()
        {
            List<Player> playerList = _scraperService.GetCurrentPlayers();
            return View(playerList);
        }

        //public IActionResult Index(FormCollection form)
        //{
        //    List<Player> playerList = _scraperService.GetCurrentPlayers();
        //    return View(playerList);
        //}
    }
}
