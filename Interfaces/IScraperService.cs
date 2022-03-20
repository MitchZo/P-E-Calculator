using KTC_Scraper.Models;

namespace KTC_Scraper.Interfaces
{
    public interface IScraperService
    {
        public void UpsertPlayer(Player player);
        public void AddPlayer( Player player);
    }
}
