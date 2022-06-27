
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int playerID { get; set; }
        public string playerName { get; set; }
        public string slug { get; set; }
        public string position { get; set; }
        public int positionID { get; set; }
        public string team { get; set; }
        public bool rookie { get; set; }
        public int age { get; set; }
        public int heightFeet { get; set; }
        public int heightInches { get; set; }
        public int weight { get; set; }
        public int seasonsExperience { get; set; }
        public int pickRound { get; set; }
        public int pickNum { get; set; }
        public bool isFeatured { get; set; }
        public bool isTrending { get; set; }
        public Oneqbvalues oneQBValues { get; set; }
        public Superflexvalues superflexValues { get; set; }
        public int number { get; set; }
        public string teamLongName { get; set; }
        public string birthday { get; set; }
        public int draftYear { get; set; }
        public string college { get; set; }
        public int byeWeek { get; set; }
        public Nflschedule nflSchedule { get; set; }
    }
}