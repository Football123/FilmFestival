using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Jazzs")]
    public class Jazz : Event
    {
        public virtual Artist Band { get; set; }
        
    }
}