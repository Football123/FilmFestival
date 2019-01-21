using System;
using System.Collections.Generic;
using System.Linq;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Models
{
    public class EventViewModel
    {
        private IEventRepository eventrepository = new EventRepository();

        // Met deze methode wordt slechts één keer de lijst met events doorlopen, en haalt het meteen alle benodigde waarden op.
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
        
        public IEnumerable<DayOfWeek> days { get; set; }
        public IEnumerable<DateTime> times { get; set; }
    }
}