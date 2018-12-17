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
      //  private IHistoricRepository historicrepository = new HistoricRepository();

        public HistoricViewModel(HistoricRepository historicrepository)
        {
            this.Stops = historicrepository.GetStops();
            this.Historics = historicrepository.GetHistoricEvents();
            this.eventsLeft = AvailableEvents();
            this.historicsLeft = getHistoricsLeft();
            this.days = getDays(eventsLeft);
            this.times = getStartTime(eventsLeft);
            this.languages = getlanguages();
        }

        private IEnumerable<Historic> getHistoricsLeft()
        {
            List<Historic> left = new List<Historic>();
            foreach (Historic historic in Historics)
            {
                foreach (Event Event in eventsLeft)
                {
                    if (historic.Id.Equals(Event.Id))
                        left.Add(historic);
                }
            }
            return left;
        }

        private IEnumerable<Event> AvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;
            ordered = historicrepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in this.Historics)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }

        private IEnumerable<Language> getlanguages()
        {
            List<Language> languages = new List<Language>();
            foreach (Historic historic in historicsLeft)
            {
                if (!languages.Contains(historic.Languages))
                    languages.Add(historic.Languages);
            }
            return languages;
        }


        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<HistoricStop> Stops { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Historic> historicsLeft { get; set; }
        public IEnumerable<Historic> Historics { get; set; }

    }
}