using System;
using System.Collections.Generic;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    public class EventRepository : IEventRepository
    {
        public HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();

        public IEnumerable<Location> GetLocations()
        {
            IEnumerable<Location> Locations = db.Locations;
            return Locations;
        }

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            IEnumerable<OrderRecord> ordered = db.OrderRecords;
            foreach (OrderRecord order in ordered)
            {
                Console.WriteLine(order.Event.Id);
            }
            return ordered;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            IEnumerable<Event> events = db.Events;
            return events;
        }

        public Event GetEvent(int eventId)
        {
            Event @event = db.Events.Find(eventId);
            return @event;
        }
    }
}