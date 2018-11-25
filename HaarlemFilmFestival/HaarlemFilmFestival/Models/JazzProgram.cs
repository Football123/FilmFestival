using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class JazzProgram
    {
        public Jazz Jazz { get; set; }
        public Event Event { get; set; }
        public Location Location { get; set; }
    }
}