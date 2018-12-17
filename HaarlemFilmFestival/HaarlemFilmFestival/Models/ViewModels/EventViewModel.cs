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
            List<DateTime> date = new List<DateTime>();
            foreach (Event Event in eventsLeft)
            {
                if (!date.Any(d => d.Day == Event.StartTime.Day))
                    date.Add(Event.StartTime);
            }
            return date;
        }

        //private IEnumerable<Event> AvailibleEvents()
        //{
        //    AllFood = foodrepository.GetFoods();
        //    IEnumerable<OrderRecord> ordered = foodrepository.GetOrderedEvents();
        //    List<Event> Events = new List<Event>();
        //    foreach (Event Event in AllFood)
        //    {
        //        int Count = 0;
        //        foreach (OrderRecord orderrecord in ordered)
        //            Count = Count + orderrecord.RecordAmount;
        //        if (Count < Event.Capacity)
        //            Events.Add(Event);
        //    }
        //    return Events;
        //}

        public IEnumerable<DateTime> days { get; set; }
        public IEnumerable<DateTime> times { get; set; }
    }
}