using System;
using System.Collections.Generic;
using System.Linq;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Models
{
    public class EventViewModel
    {
        private IEventRepository eventrepository = new EventRepository();

        public void getStarts(IEnumerable<Event> eventsLeft, out List<DateTime> starttimes, out List<DateTime> endtimes, out List<DayOfWeek> days)
        {
            starttimes = new List<DateTime>();
            endtimes = new List<DateTime>();
            days = new List<DayOfWeek>();
            foreach (var item in eventsLeft)
            {
                if (!starttimes.Any(d => d.Hour == item.StartTime.Hour))
                    starttimes.Add(item.StartTime);
                if (!endtimes.Any(d => d.Hour == item.EndTime?.Hour))
                    endtimes.Add(item.EndTime.Value);
                if (!days.Contains(item.StartTime.DayOfWeek))
                    days.Add(item.StartTime.DayOfWeek);
            }
        }

        //public IEnumerable<DateTime> getStartTime(IEnumerable<Event> eventsLeft)
        //{
        //    List<DateTime> times = new List<DateTime>();

        //    foreach (Event Event in eventsLeft)
        //    {
        //        if (!times.Any(d => d.Hour == Event.StartTime.Hour))
        //            times.Add(Event.StartTime);
        //    }
        //    return times;
        //}

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
            List<DayOfWeek> dayofweeks = new List<DayOfWeek>();
            List<DateTime> dates = new List<DateTime>();
            foreach (var e in eventsLeft)
            {
                if (!dayofweeks.Contains(e.StartTime.DayOfWeek))
                {
                    dayofweeks.Add(e.StartTime.DayOfWeek);
                    dates.Add(e.StartTime);
                }
            }
            return dates;
        }

        public IEnumerable<DayOfWeek> days { get; set; }
        public IEnumerable<DateTime> dates { get; set; }
        public IEnumerable<DateTime> times { get; set; }
    }
}