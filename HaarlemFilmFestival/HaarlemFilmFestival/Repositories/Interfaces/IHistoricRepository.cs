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
        Historic GetHistoricEvent(int id);
        IEnumerable<Historic> GetPerDayAndTime(DateTime daytime);
        IEnumerable<Historic> GetHistoricPerTime(DateTime time);
        IEnumerable<Historic> GetHistoricPerDay(DateTime day);
        IEnumerable<HistoricStop> GetStops();
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Historic> GetHistoricEvents();
        IEnumerable<TimeSpan> GetStartTimes();

    }
}
