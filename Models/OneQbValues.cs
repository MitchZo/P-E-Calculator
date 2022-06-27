using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("OneQbValues")]
    public class Oneqbvalues
    {
        [Key]
        public int OneQbValuesId { get; set; }
        public int value { get; set; }
        public int startSitValue { get; set; }
        public int rank { get; set; }
        public int overallTrend { get; set; }
        public int positionalTrend { get; set; }
        public object rookieTrend { get; set; }
        public object rookiePositionalTrend { get; set; }
        public int positionalRank { get; set; }
        public object rookieRank { get; set; }
        public object rookiePositionalRank { get; set; }
        public object[] history { get; set; }
        public int kept { get; set; }
        public int traded { get; set; }
        public int cut { get; set; }
        public int diff { get; set; }
        public int overallTier { get; set; }
        public int positionalTier { get; set; }
        public object rookieTier { get; set; }
        public object rookiePositionalTier { get; set; }
        public int overall7DayTrend { get; set; }
        public int positional7DayTrend { get; set; }
        public int startSitOverallRank { get; set; }
        public int startSitPositionalRank { get; set; }
        public object startSitOverallTier { get; set; }
        public object startSitPositionalTier { get; set; }
        public object startSitOneQBFlexTier { get; set; }
        public object startSitSuperflexFlexTier { get; set; }
        public bool isOutThisWeek { get; set; }
    }
}