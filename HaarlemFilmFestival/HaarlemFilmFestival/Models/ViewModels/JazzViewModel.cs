using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.ViewModels
{
    public class JazzViewModel : EventViewModel
    {
        public IEnumerable<Location> JazzLocations { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Jazz> Jazzs { get; set; }
        public IEnumerable<DateTime> StartTime { get; set; }
        public IEnumerable<DateTime> EndTime { get; set; }
        public IEnumerable<Jazz> JazzLeft { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Jazz> AllJazz { get; set; }
        private IJazzRepository jazzRepository = new JazzRepository();
        private IEventRepository eventRepository = new EventRepository();

        public JazzViewModel()
        {
            AllJazz = jazzRepository.GetJazz();
            this.eventsLeft = AvailableEvents();
            this.JazzLeft = getJazzsLeft();
            this.JazzLocations = jazzRepository.GetJazzLocation();
            this.Artists = jazzRepository.GetArtists(AllJazz);
            this.StartTime = getStartTime(eventsLeft);
            this.EndTime = getEndTime(eventsLeft);
            this.Events = eventRepository.GetAllEvents();
        }

        private IEnumerable<Jazz> getJazzsLeft()
        {
            AllJazz = jazzRepository.GetJazz();
            List<Jazz> left = new List<Jazz>();
            foreach (Jazz jazz in AllJazz)
            {
                foreach (Event Event in eventsLeft)
                {
                    if (jazz.Id.Equals(Event.Id))
                        left.Add(jazz);
                }
            }
            return left;
        }

        protected IEnumerable<Event> AvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;
            AllJazz = jazzRepository.GetJazz();
           ordered = jazzRepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in AllJazz)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }     
    }
}