﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace KTC_Scraper.Models
{
    [Table("Player")]
    [Index("NflscheduleId", Name = "IX_Player_NflscheduleId")]
    [Index("OneQbValuesId", Name = "IX_Player_OneQbValuesId")]
    [Index("SuperflexValuesId", Name = "IX_Player_SuperflexValuesId")]
    public partial class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int playerID { get; set; }
        public string playerName { get; set; }
        public string slug { get; set; }
        public string position { get; set; }
        public int? positionID { get; set; }
        public string team { get; set; }
        public bool? rookie { get; set; }
        public int? age { get; set; }
        public int? heightFeet { get; set; }
        public int? heightInches { get; set; }
        public int? weight { get; set; }
        public int? seasonsExperience { get; set; }
        public int? pickRound { get; set; }
        public int? pickNum { get; set; }
        public bool isFeatured { get; set; }
        public bool isTrending { get; set; }
        public int? OneQbValuesId { get; set; }
        public int? SuperflexValuesId { get; set; }
        public int number { get; set; }
        public string teamLongName { get; set; }
        public string birthday { get; set; }
        public int? draftYear { get; set; }
        public string college { get; set; }
        public int? byeWeek { get; set; }
        public int? NflscheduleId { get; set; }

        [ForeignKey("NflscheduleId")]
        [InverseProperty("Players")]
        public virtual NflSchedule Nflschedule { get; set; }
        [ForeignKey("OneQbValuesId")]
        [InverseProperty("Players")]
        public virtual OneQbValue OneQbValues { get; set; }
        [ForeignKey("SuperflexValuesId")]
        [InverseProperty("Players")]
        public virtual SuperflexValue SuperflexValues { get; set; }
    }
}