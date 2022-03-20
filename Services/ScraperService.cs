using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using System.Data;
using System.Data.SqlClient;

namespace KTC_Scraper
{
    public class ScraperService : IScraperService
    {
        IConnectionString _context;
        
        public ScraperService(ConnectionString context)
        {
            _context = context;
        }

        public void UpsertPlayer(Player player)
        {
            using (var conn = new SqlConnection(_context.ConnectionStringVal("ktcContext")))
            using (var command = new SqlCommand("UpsertPlayer", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(new SqlParameter("@PlayerID",player.PlayerID));
                command.ExecuteNonQuery();
            }
        }
        public void AddPlayer(Player player)
        {

        }
    }
}
