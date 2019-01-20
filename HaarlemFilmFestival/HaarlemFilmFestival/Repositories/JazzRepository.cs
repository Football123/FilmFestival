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
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();
        private IEventRepository eventRepository = new EventRepository();

        // Deze methode haalt de hele Jazz-tabel op
        public IEnumerable<Jazz> GetJazz()
        {
            IEnumerable<Jazz> Jazzs = db.Jazzs;
            return Jazzs;
        }

        // Deze methode haalt alle Jazz-events op, op basis van de id
        public Jazz GetJazz(int jazzId)
        {
            Jazz jazz = db.Jazzs.Find(jazzId);
            return jazz;
        }

        // Deze methode haalt de bijbehorende artiesten van een jazz-event op, met behulp van het id
        public IEnumerable<Artist> GetArtists(IEnumerable<Jazz> Jazzevents)
        {
            List<Artist> artists = new List<Artist>();
            Artist a;
            foreach (Jazz e in Jazzevents)
            {
                a = db.Artists.Where(j => j.Id == e.Band.Id).SingleOrDefault();
                artists.Add(a);
            }
            return artists.Distinct();
        }

        // Deze methode haalt de Jazz-events op per dag op basis van de dag die meegegeven word via de button op de pagina
        public IEnumerable<Jazz> GetJazzPerDay(DateTime day)
        {
            IEnumerable<Jazz> events = db.Jazzs.Where(a => DbFunctions.TruncateTime(a.StartTime) == day.Date);
            return events;
        }
    }
}