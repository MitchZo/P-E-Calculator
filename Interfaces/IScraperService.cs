using KTC_Scraper.Models;
using System.Collections.Generic;

namespace KTC_Scraper.Interfaces
{
    public interface IScraperService
    {
        public List<Player> GetCurrentPlayers();
    }
}
