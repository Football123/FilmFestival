﻿using System;
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

        public IEnumerable<Artist> GetArtists(IEnumerable<Jazz> Jazzevents)
        {
            List<Artist> artists = new List<Artist>();
            Artist a;
            foreach (Jazz e in Jazzevents)
            {
                a = db.Artists.Where(j => j.Id == e.Band.Id).SingleOrDefault();
                artists.Add(a);
            }
            return artists;
        }
    }
}