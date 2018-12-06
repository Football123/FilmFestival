using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Repositories
{
    interface IJazzRepository
    {
        IEnumerable<Event> GetAllJazz();
        IEnumerable<Jazz> GetJazzs();
        Jazz GetJazz(int jazzId);
        void AddJazz(Jazz jazz);
        void UpdateJazz(Jazz jazz);
        void DeleteJazz(int jazzId);
    }
}