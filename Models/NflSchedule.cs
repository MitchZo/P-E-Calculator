using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("NflSchedule")]
    public class Nflschedule
    {
        [Key]
        public int NflscheduleId { get; set; }
        public string kickoff { get; set; }
        public string gameSecondsRemaining { get; set; }
        public Team[] team { get; set; }
    }
}
