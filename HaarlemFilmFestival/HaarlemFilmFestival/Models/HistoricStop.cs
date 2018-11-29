using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class HistoricStop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StopDescription { get; set; }

        // Koppeling naar Locatie
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}