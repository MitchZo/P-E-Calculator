namespace KTC_Scraper.Models
{
    public class OneQbValues : PlayerValues
    {
        public int OneQbValueId { get; set; }

        public OneQbValues()
        {
            ScoringTypeDescription = "OneQB";
        }
    }
}