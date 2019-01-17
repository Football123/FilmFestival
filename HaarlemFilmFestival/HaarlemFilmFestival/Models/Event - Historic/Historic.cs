using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("Historics")]
    public class Historic : Event
    {
        public Language Languages { get; set; } 
    }
}