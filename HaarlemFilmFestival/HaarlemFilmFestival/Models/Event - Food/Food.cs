using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Foods")]
    public class Food : Event
    {
       // De Food event geeft een Restaurant mee
        public virtual Restaurant Restaurant { get; set; }
        

    }
}