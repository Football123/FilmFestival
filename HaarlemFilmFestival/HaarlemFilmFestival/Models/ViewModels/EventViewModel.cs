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

        public IEnumerable<DayOfWeek> getDays(IEnumerable<Event> eventsLeft)
        {
            List<DayOfWeek> days = new List<DayOfWeek>();
            foreach (var e in eventsLeft)
            {
                if (!days.Contains(e.StartTime.DayOfWeek))
                    days.Add(e.StartTime.DayOfWeek);
            }
            return days;
        }

        public IEnumerable<DayOfWeek> days { get; set; }
        public IEnumerable<DateTime> times { get; set; }
    }
}