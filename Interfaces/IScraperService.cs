using KTC_Scraper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KTC_Scraper.Interfaces
{
    public interface IScraperService
    {
        public List<Player> GetCurrentPlayers();
    }
}
