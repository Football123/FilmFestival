﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Models
{
    public class EventViewModel
    {
        private IEventRepository eventrepository = new EventRepository();

        public IEnumerable<DateTime> getTime(IEnumerable<Event> eventsLeft)
        {
            List<DateTime> times = new List<DateTime>();

            foreach (Event Event in eventsLeft)
            {
                if (!times.Any(d => d.Hour == Event.StartTime.Hour))
                    times.Add(Event.StartTime);
            }
            return times;
        }
        
        public IEnumerable<DateTime> getDays(IEnumerable<Event> eventsLeft)
        {
            List<DateTime> date = new List<DateTime>();
            foreach (Event Event in eventsLeft)
            {
                if (!date.Any(d => d.Day == Event.StartTime.Day))
                    date.Add(Event.StartTime);
            }
            return date;
        }

        public IEnumerable<DateTime> days { get; set; }
        public IEnumerable<DateTime> times { get; set; }

        public IEnumerable<Historic> Historics { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Dance> Dances { get; set; }
        public IEnumerable<Jazz> Jazzs { get; set; }
    }
}