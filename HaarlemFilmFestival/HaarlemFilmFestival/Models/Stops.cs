using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Stops
    {
        [Key]
        public int StopsId { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
    }
}