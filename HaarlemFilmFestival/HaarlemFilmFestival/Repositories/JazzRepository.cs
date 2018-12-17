using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Repositories
{
    public class JazzRepository : IJazzRepository
    {
        private HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext();
        private IEventRepository eventRepository = new EventRepository();

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            return eventRepository.GetOrderedEvents();
        }

        public IEnumerable<Jazz> GetJazz()
        {
            IEnumerable<Jazz> Jazzs = db.Jazzs;
            //IEnumerable<Jazz> Jazzs = db.Jazzs.Include("Artists");
            return Jazzs;
        }
        public IEnumerable<Location> GetJazzLocation()
        {
            List<Location> jazzlocations = new List<Location>();
            IEnumerable<Location> locations = eventRepository.GetLocations();
            foreach (Location location in locations)
            {
                foreach (Jazz jazzevent in db.Jazzs)
                {
                    if (jazzevent.Location_Id == location.Id)
                        jazzlocations.Add(location);
                }
            }
            return jazzlocations;
        }

        public Jazz GetJazz(int jazzId)
        {
            Jazz jazz = db.Jazzs.Find(jazzId);
            return jazz;
        }

    }
}