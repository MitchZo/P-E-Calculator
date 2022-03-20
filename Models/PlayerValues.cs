using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("PlayerValues")]
    public class PlayerValues
    {
        [Key]
        public int PlayerValueId { get; set; }
        public int ? Value { get; set; }
        public string  ScoringTypeDescription { get; set; }
        public int ? StartSitValue { get; set; }
        public int ? Rank { get; set; }
        public int ? OverallTrend { get; set; }
        public int ? PositionalTrend { get; set; }
        public int ? RookieTrend { get; set; }
        public int ? RookiePositionalTrend { get; set; }
        public int ? PositionalRank { get; set; }
        public int ? RookieRank { get; set; }
        public int ? RookiePositionalRank { get; set; }
        public string[] History { get; set; }
        public int ? Kept { get; set; }
        public int ? Traded { get; set; }
        public int ? Cut { get; set; }
        public int ? Diff { get; set; }
        public int ? OverallTier { get; set; }
        public int ? PoisitonalTier { get; set; }
        public int ? RookieTier { get; set; }
        public int ? RookiePositionalTier { get; set; }
        public int ? Overall7DayTrend { get; set; }
        public int ? Positional7DayTrend { get; set; }
        public int ? StartSitOverallRank { get; set; }
        public int ? StartSitPositionalRank { get; set; }
        public int ? StartSitOverallTier { get; set; }
        public int ? StartSitPositionalTier { get; set; }
        public int ? StartSitOneQBFlexTier { get; set; }
        public int ? StartSitSuperflexFlexTier { get; set; }
        public bool IsOutThisWeek { get; set; }
    }
}
