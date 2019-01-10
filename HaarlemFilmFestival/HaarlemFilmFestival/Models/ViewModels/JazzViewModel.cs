using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.ViewModels
{
    public class JazzViewModel : EventViewModel
    {
        public IEnumerable<Location> JazzLocations { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Jazz> Jazzs { get; set; }
        public IEnumerable<Jazz> jazzLeft { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }

        public JazzViewModel()
        {
        }
     
    }
}