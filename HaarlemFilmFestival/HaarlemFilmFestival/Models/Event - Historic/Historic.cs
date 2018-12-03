using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Historic")]
    public class Historic : Event
    {
        public Language Languages { get; set; } 
    }
}