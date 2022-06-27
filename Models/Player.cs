
using System;
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
        public Nullable<int> positionID { get; set; }
        public string team { get; set; }
        public Nullable<bool> rookie { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> heightFeet { get; set; }
        public Nullable<int> heightInches { get; set; }
        public Nullable<int> weight { get; set; }
        public Nullable<int> seasonsExperience { get; set; }
        public Nullable<int> pickRound { get; set; }
        public Nullable<int> pickNum { get; set; }
        public bool isFeatured { get; set; }
        public bool isTrending { get; set; }
        public Oneqbvalues oneQBValues { get; set; }
        public Superflexvalues superflexValues { get; set; }
        public int number { get; set; }
        public string teamLongName { get; set; }
        public string birthday { get; set; }
        public Nullable<int> draftYear { get; set; }
        public string college { get; set; }
        public Nullable<int> byeWeek { get; set; }
        public Nflschedule nflSchedule { get; set; }
    }
}