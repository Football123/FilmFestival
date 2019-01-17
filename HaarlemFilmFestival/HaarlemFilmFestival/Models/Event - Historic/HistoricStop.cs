using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("HistoricStops")]
    public class HistoricStop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StopDescription { get; set; }

        // Koppeling naar Locatie
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_Id { get; set; }
        [ForeignKey("Location_Id")]
        public virtual Location Location { get; set; }
    }
}