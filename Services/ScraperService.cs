using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using System.Data;
using System.Data.SqlClient;

namespace KTC_Scraper
{
    public class ScraperService : IScraperService
    {
        IConnectionString _context;
        
        public ScraperService(IConnectionString context)
        {
            _context = context;
        }

        public void UpsertPlayer(Player player)
        {

        }
        public void AddPlayer(Player player)
        {

        }
    }
}
