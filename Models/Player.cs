namespace KTC_Scraper.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int ? PlayerID { get; set; }
        public string  Slug { get; set; }
        public string Position { get; set; }
        public int ? PositionID { get; set; }
        public string Team { get; set; }
        public bool Rookie { get; set; }
        public int ? Age { get; set; }
        public int ? HeightFeet { get; set; }
        public int ? HeightInches { get; set; }
        public int ? Weight { get; set; }
        public int ? SeasonsExperience { get; set; }
        public int ? PickRound { get; set; }
        public int ? PickNum { get; set; }
        public bool IsFeatured { get; set; }
        public OneQbValues OneQbValues { get; set; }
        public SuperflexValues SuperFlexValues { get; set; }
        public int ? Number { get; set; }
        public string TeamLongName { get; set; }
        public int ? Birthday { get; set; }
        public int ? DraftYear { get; set; }
        public string College { get; set; }
        public int ? ByeWeek { get; set; }
        public NflSchedule NflSchedule { get; set; }
    }
}