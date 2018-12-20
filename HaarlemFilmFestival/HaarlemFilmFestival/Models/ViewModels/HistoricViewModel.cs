using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;
using HaarlemFilmFestival.ViewModels;

namespace HaarlemFilmFestival.Models
{
    public class HistoricViewModel : EventViewModel
    {
        public HistoricViewModel()
        {
        }
        
        public IEnumerable<Historic> historicPerDay { get; set; }
        public IEnumerable<TimeSpan> StartTimes { get; set; }
        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<HistoricStop> Stops { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Historic> historicsLeft { get; set; }
        public IEnumerable<Historic> Historics { get; set; }

    }
}