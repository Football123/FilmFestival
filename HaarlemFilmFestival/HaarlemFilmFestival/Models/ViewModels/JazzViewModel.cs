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
            this.Artists = GetArtists();
        }
        private IEnumerable<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (Location location in Locations)
            {
                foreach (Jazz jazz in Jazzs)
                {
                    if (location.Id.Equals(jazz.Location_Id))
                        locations.Add(location);
                }
            }
            return locations;
        }
        private IEnumerable<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>();
            foreach (Artist artist in Artists)
            {
                foreach (Jazz jazz in Jazzs)
                {
                    if (artist.Id.Equals(jazz.Band))
                        artists.Add(artist);
                }
            }
            return artists;
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