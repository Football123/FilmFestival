using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.ViewModels
{
    public class JazzViewModel
    {
        private IJazzRepository jazzRepository = new JazzRepository();
        public JazzViewModel()
        {
            this.Jazzs = jazzRepository.GetJazz();
            this.StartTime = jazzRepository.GetJazz();
            this.EndTime = jazzRepository.GetJazz();
            this.Locations = GetLocations();
            this.Price = jazzRepository.GetJazz();
            this.Artists = jazzRepository.GetArtist();
        }
        private IEnumerable<Location> GetLocations()
        {
            IEnumerable<Location> locations = jazzRepository.GetLocation();
            List<Location> list = new List<Location>();
            foreach (Location location in locations)
            {
                foreach (Jazz jazz in this.Jazzs)
                {
                    if (location.Id.Equals(jazz.Location_Id))
                        list.Add(location);
                }
            }
            return list;
        }
        private IEnumerable<Artist> GetArtists()
        {
            IEnumerable<Artist> artists = jazzRepository.GetArtist();
            List<Artist> list = new List<Artist>();
            foreach (Artist artist in artists)
            {
                foreach (Jazz jazz in Jazzs)
                {
                    if (artist.Id.Equals(jazz.Band))
                        list.Add(artist);
                }
            }
            return list;
        }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Jazz> Jazzs { get; set; }
        public IEnumerable<Event> StartTime { get; set; }
        public IEnumerable<Event> EndTime { get; set; }
        public IEnumerable<Location> Name { get; set; }
        public IEnumerable<Location> LocationDescription { get; set; }
        public IEnumerable<Event> Price { get; set; }
        public IEnumerable<Artist> NameOfBand { get; set; }
        public IEnumerable<Artist> ArtistDescription { get; set; }
    }
}