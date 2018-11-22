using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Dance
    {
        public int DanceId { get; set; }
        public string Artist { get; set; }
        public string Session { get; set; }
        public int EventId { get; set; }
    }
}