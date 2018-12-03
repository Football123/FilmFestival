using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Jazz")]
    public class Jazz : Event
    {
        public Artist Band { get; set; }
    }
}