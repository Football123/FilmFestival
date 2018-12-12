using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;

namespace HaarlemFilmFestival.Repositories
{
    public class JazzRepository : IJazzRepository
    {
        private HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext();
        public void AddJazz(Jazz jazz)
        {
            db.Jazzs.Add(jazz);
            db.SaveChanges();
        }

        public void DeleteJazz(int jazzId)
        {
            Jazz jazz = db.Jazzs.Find(jazzId);
            db.Jazzs.Remove(jazz);
            db.SaveChanges();
        }

        public IEnumerable<Jazz> GetJazz()
        {
            IEnumerable<Jazz> Jazzs = db.Jazzs;
            return Jazzs;
        }
        public IEnumerable<Location> GetLocation()
        {
            IEnumerable<Location> Locations = db.Locations;
            return Locations;
        }

        public Jazz GetJazz(int jazzId)
        {
            Jazz jazz = db.Jazzs.Find(jazzId);
            return jazz;
        }
        
        public void UpdateJazz(Jazz jazz)
        {
            db.Entry(jazz).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Artist> GetArtist()
        {
            IEnumerable<Artist> Artists = db.Artists;
            return Artists;
        }
    }
}