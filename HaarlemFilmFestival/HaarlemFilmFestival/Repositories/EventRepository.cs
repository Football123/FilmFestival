using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;

namespace HaarlemFilmFestival.Repositories
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext();
        public void AddEvent(Event @event)
        {
            db.Events.Add(@event);
            db.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            Event @event = db.Events.Find(eventId);
            db.Events.Remove(@event);
            db.SaveChanges();
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

        public void UpdateEvent(Event @event)
        {
            db.Entry(@event).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}