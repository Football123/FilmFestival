using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Themes")]
    public class Theme
    {
        public int Id { get; set; }
        public string ThemeDescription { get; set; }

        // Koppeling naar Artiest
        public virtual ICollection<Artist> Artists { get; set; }
    }
}