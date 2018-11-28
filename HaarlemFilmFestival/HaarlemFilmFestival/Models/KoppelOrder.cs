using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class KoppelOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderregelId { get; set; }
    }
}