using System;
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

        public IEnumerable<DateTime> getStartTime(IEnumerable<Event> eventsLeft)
        {
            List<DateTime> times = new List<DateTime>();

            foreach (Event Event in eventsLeft)
            {
                if (!times.Any(d => d.Hour == Event.StartTime.Hour))
                    times.Add(Event.StartTime);
            }
            return times;
        }

        public IEnumerable<DateTime> getEndTime(IEnumerable<Event> eventsLeft)
        {
            List<DateTime> times = new List<DateTime>();

            foreach (Event Event in eventsLeft)
            {
                if (!times.Any(d => d.Hour == Event.EndTime?.Hour))
                    times.Add(Event.EndTime.Value);
            }
            return times;
        }

        public IEnumerable<DateTime> getDays(IEnumerable<Event> eventsLeft)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (var e in eventsLeft)
            {
                if (!days.Contains(e.StartTime))
                    days.Add(e.StartTime);
            }
            return days;
        }

        public IEnumerable<DateTime> days { get; set; }
        public IEnumerable<DateTime> times { get; set; }
    }
}