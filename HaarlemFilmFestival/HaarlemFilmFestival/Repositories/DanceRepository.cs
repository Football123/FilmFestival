using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;
using HaarlemFilmFestival.Repositories.Interfaces;

namespace HaarlemFilmFestival.Repositories
{
    public class DanceRepository : IDanceRepository
    {
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();
        private IEventRepository eventRepository = new EventRepository();

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            return eventRepository.GetOrderedEvents();
        }

        public IEnumerable<Dance> GetDance()
        {
            IEnumerable<Dance> Dances = db.Dances;
            return Dances;
        }
        public IEnumerable<Location> GetDanceLocation()
        {
            List<Location> dancelocations = new List<Location>();
            IEnumerable<Location> locations = eventRepository.GetLocations();
            foreach (Location location in locations)
            {
                foreach (Dance danceevent in db.Dances)
                {
                    if (danceevent.Location_Id == location.Id)
                        dancelocations.Add(location);
                }
            }
            return dancelocations;
        }

        public Dance GetDance(int danceId)
        {
            Dance dance = db.Dances.Find(danceId);
            return dance;
        }

        public IEnumerable<Artist> GetArtist()
        {
            
            IEnumerable<Artist> artists = db.Artists;
            return artists;
        }


    }

}