using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace KTC_Scraper.Models
{
    public class KtcContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerValues> PlayerValues { get; set; }
    }
}
