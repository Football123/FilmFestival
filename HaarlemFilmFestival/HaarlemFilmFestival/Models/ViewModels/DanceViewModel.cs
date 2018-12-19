using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.ViewModels
{
    public class DanceViewModel : EventViewModel
    {
        private IDanceRepository danceRepository = new DanceRepository();
        private IEventRepository eventRepository = new EventRepository();

        public DanceViewModel()
        {
            this.eventsLeft = AvailableEvents();
            //this.DanceLeft = getDancesLeft();
            this.DanceLocations = danceRepository.GetDanceLocation();
            this.Artists = danceRepository.GetArtist();
            this.StartTime = getStartTime(eventsLeft);
            this.EndTime = getEndTime(eventsLeft);
            this.Events = eventRepository.GetAllEvents();
        }

        //private IEnumerable<Dance> getDancesLeft()
        //{
        //    AllDance = danceRepository.GetDance();
        //    List<Dance> left = new List<Dance>();
        //    foreach (Dance dance in AllDance)
        //    {
        //        foreach (Event Event in eventsLeft)
        //        {
        //            if (dance.Id.Equals(Event.Id))
        //                left.Add(dance);
        //        }
        //    }
        //    return left;
        //}

        protected IEnumerable<Event> AvailableEvents()
        {
            AllDance = danceRepository.GetDance();
            IEnumerable<OrderRecord> ordered = danceRepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in Events)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }


        private IEnumerable<Artist> GetArtists()
        {
            AllDance = danceRepository.GetDance();
           IEnumerable<Artist> artists = danceRepository.GetArtist();
            List<Artist> list = new List<Artist>();
           foreach (Artist artist in artists)
            {
                foreach (Dance dance in AllDance)
                {
                   
                }
            }
            return list;
        }

        public IEnumerable<Location> DanceLocations { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Dance> Dances { get; set; }
        public IEnumerable<DateTime> StartTime { get; set; }
        public IEnumerable<DateTime> EndTime { get; set; }
        public IEnumerable<Dance> DanceLeft { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Event> AllDance { get; set; }
    }

}