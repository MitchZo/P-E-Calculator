using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTC_Scraper.Models
{
    [Table("PlayerValues")]
    public class PlayerValues
    {
        [Key]
        public string PlayerValuesId { get; set; }
        Superflexvalues Superflexvalues { get; set; }
        Oneqbvalues Oneqbvalues { get; set; }
    }
}
