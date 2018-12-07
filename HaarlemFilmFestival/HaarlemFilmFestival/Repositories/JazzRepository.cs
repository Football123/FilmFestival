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

        public IEnumerable<Event> GetAllJazz()
        {
            List<Event> JazzEvents = new List<Event>();
            IEnumerable<Jazz> Jazzs = GetJazzs();
            foreach (Jazz jazz in Jazzs)
            {
                Event jazzevent = db.Events.Where(je => je.Id == jazz.Id).Include("Location").FirstOrDefault();
                JazzEvents.Add(jazzevent);
            }
            return JazzEvents;
        }
        
        public Jazz GetJazz(int jazzId)
        {
            Jazz jazz = db.Jazzs.Find(jazzId);
            return jazz;
        }

        public IEnumerable<Jazz> GetJazzs()
        {
            IEnumerable<Jazz> jazzs = db.Jazzs;
            return jazzs;
        }

        public void UpdateJazz(Jazz jazz)
        {
            db.Entry(jazz).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}