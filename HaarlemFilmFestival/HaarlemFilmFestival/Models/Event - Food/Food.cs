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
       // public string Restaurant_Id { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}