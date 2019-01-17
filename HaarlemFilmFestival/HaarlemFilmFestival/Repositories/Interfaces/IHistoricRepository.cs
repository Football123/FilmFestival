using System;
using System.Collections.Generic;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    interface IHistoricRepository
    {
        Historic GetHistoricById(int Event_Id);
        IEnumerable<Historic> GetPerDayAndTime(DateTime daytime);
        IEnumerable<Historic> GetHistoricPerTime(DateTime time);
        IEnumerable<Historic> GetHistoricPerDay(DateTime day);
        IEnumerable<HistoricStop> GetStops();
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Historic> GetHistoricEvents();
        IEnumerable<TimeSpan> GetStartTimes();

    }
}
