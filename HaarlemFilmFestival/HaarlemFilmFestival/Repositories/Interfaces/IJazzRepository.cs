using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Repositories
{
    interface IJazzRepository
    {
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Jazz> GetJazz();
        IEnumerable<Location> GetJazzLocation();
        IEnumerable<Artist> GetArtist();
        Jazz GetJazz(int jazzId);
        void AddJazz(Jazz jazz);
        void UpdateJazz(Jazz jazz);
        void DeleteJazz(int jazzId);
    }
}