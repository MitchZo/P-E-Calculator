namespace KTC_Scraper.Models
{
    public class NflSchedule
    {
        public string Kickoff { get; set; }
        public string GameSecondsRemaining { get; set; }
        public Team[] Team { get; set; }

    }
}
