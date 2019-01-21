using HaarlemFilmFestival.Models;
using System.Collections.Generic;

namespace HaarlemFilmFestival.ViewModels
{
    public class JazzViewModel : EventViewModel
    {
        public JazzViewModel()
        {
        }

        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Jazz> Jazzs { get; set; }
        public IEnumerable<Jazz> jazzLeft { get; set; }
        public IEnumerable<Jazz> jazzPerDay { get; set; }
    }
}