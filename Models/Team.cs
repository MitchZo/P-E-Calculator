using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string inRedZone { get; set; }
        public string score { get; set; }
        public string hasPossession { get; set; }
        public string passOffenseRank { get; set; }
        public string rushOffenseRank { get; set; }
        public string passDefenseRank { get; set; }
        public string spread { get; set; }
        public string isHome { get; set; }
        public string id { get; set; }
        public string rushDefenseRank { get; set; }
    }
}
