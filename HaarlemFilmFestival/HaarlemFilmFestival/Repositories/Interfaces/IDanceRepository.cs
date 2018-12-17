using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    interface IDanceRepository
    {
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Dance> GetDance();
        IEnumerable<Location> GetDanceLocation();
        IEnumerable<Artist> GetArtist();
        Dance GetDance(int danceId);

    }
}
