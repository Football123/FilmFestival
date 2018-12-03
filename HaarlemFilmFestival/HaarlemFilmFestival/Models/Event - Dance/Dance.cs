using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Dance")]
    public class Dance : Event
    {
        public int Theme_Id { get; set; }
        public int Artist_Id { get; set; }

        //navigation properties
        public virtual Theme Theme { get; set; }
        public virtual Artist Artist { get; set; }

        // Koppeling naar Session
        public virtual ICollection<Theme> Themes { get; set; }
        
    }
}