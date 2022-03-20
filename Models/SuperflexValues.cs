namespace KTC_Scraper.Models
{
    public class SuperflexValues : PlayerValues
    {
        public int SuperflexValueId { get; set; }

        public SuperflexValues ()
        {
            ScoringTypeDescription = "SuperFlex";
        }
    }
}
