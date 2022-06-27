using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("SuperflexValues")]
    public class Superflexvalues
    {
        [Key]
        public int SuperflexValuesId { get; set; }
        public int value { get; set; }
        public int startSitValue { get; set; }
        public int rank { get; set; }
        public Nullable<int> overallTrend { get; set; }
        public Nullable<int> positionalTrend { get; set; }
        public Nullable<int> rookieTrend { get; set; }
        public Nullable<int> rookiePositionalTrend { get; set; }
        public Nullable<int> positionalRank { get; set; }
        public Nullable<int> rookieRank { get; set; }
        public Nullable<int> rookiePositionalRank { get; set; }
        public object[] history { get; set; }
        public int kept { get; set; }
        public int traded { get; set; }
        public int cut { get; set; }
        public int diff { get; set; }
        public Nullable<int> overallTier { get; set; }
        public Nullable<int> positionalTier { get; set; }
        public Nullable<int> rookieTier { get; set; }
        public Nullable<int> rookiePositionalTier { get; set; }
        public Nullable<int> overall7DayTrend { get; set; }
        public Nullable<int> positional7DayTrend { get; set; }
        public Nullable<int> startSitOverallRank { get; set; }
        public Nullable<int> startSitPositionalRank { get; set; }
        public Nullable<int> startSitOverallTier { get; set; }
        public Nullable<int> startSitPositionalTier { get; set; }
        public Nullable<int> startSitOneQBFlexTier { get; set; }
        public Nullable<int> startSitSuperflexFlexTier { get; set; }
        public Nullable<bool> isOutThisWeek { get; set; }
    }
}