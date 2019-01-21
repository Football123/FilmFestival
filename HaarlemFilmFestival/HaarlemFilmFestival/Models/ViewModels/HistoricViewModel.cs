using System.Collections.Generic;

namespace HaarlemFilmFestival.Models
{
    public class HistoricViewModel : EventViewModel
    {
        public HistoricViewModel()
        {
        }
        
        public IEnumerable<Historic> historicPerDay { get; set; }
        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<HistoricStop> Stops { get; set; }
        public IEnumerable<Historic> historicsLeft { get; set; }
        public IEnumerable<Historic> Historics { get; set; }
    }
}