using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Controllers;

namespace HaarlemFilmFestival.Repositories
{
   interface IHistoricRepository
    {
        IEnumerable<HistoricStop> GetStops();
        IEnumerable<Historic> GetHistoricEvents();
        IEnumerable<OrderRecord> GetOrderedEvents();
    }
}
