using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;

namespace HaarlemFilmFestival.Models
{
    public class HistoricViewModel
    {
        private IHistoricRepository historicrepository = new HistoricRepository();

        public HistoricViewModel()
        {
            this.Stops = historicrepository.GetStops();
            this.Historics = historicrepository.GetHistorics();
            this.eventsLeft = AvailbleEvents();
            this.historicsLeft = getHistoricsLeft();
            this.days = getDays();
            this.time = getTime();
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

        private IEnumerable<Event> AvailbleEvents()
        {
            IEnumerable<OrderRecord> ordered = historicrepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in this.Historics)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                {
                    Count = Count + orderrecord.RecordAmount;
                }
                if (Count < Event.Capacity)
                {
                    Events.Add(Event);
                }
            }
            return Events;
        }

        private IEnumerable<Language> getlanguages()
        {
            List<Language> languages = new List<Language>();
            foreach (Historic historic in historicsLeft)
            {
                if (!languages.Contains(historic.Languages))
                {
                    languages.Add(historic.Languages);
                }
            }
            return languages;
        }

        private IEnumerable<DateTime> getTime()
        {
            List<DateTime> time = new List<DateTime>();

            foreach (Event Event in eventsLeft)
            {
                if (!time.Any(d => d.Hour == Event.StartTime.Hour))
                {
                    time.Add(Event.StartTime);
                }

            }
            return time;
        }

        private IEnumerable<DateTime> getDays()
        {
            List<DateTime> date = new List<DateTime>();
            foreach (Event Event in eventsLeft)
            {
                if (!date.Any(d => d.Day == Event.StartTime.Day))
                {
                    date.Add(Event.StartTime);
                }
            }
            return date;
        }

        public IEnumerable<HistoricStop> Stops { get; set; }
        public IEnumerable<Historic> Historics { get; set; }
        public IEnumerable<DateTime> days { get; set; }
        public IEnumerable<DateTime> time { get; set; }
        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Historic> historicsLeft { get; set; }

    }
}