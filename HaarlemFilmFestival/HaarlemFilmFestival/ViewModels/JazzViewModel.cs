using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.ViewModels
{
    public class JazzViewModel
    {
        public Event Begintijd { get; set; }
        public Event Eindtijd { get; set; }
        public Location Naam { get; set; }
        public Jazz Rang { get; set; }
        public Jazz RangPrijs { get; set; }
        public Jazz Band { get; set; }
    }
}