using System;
using System.Collections.Generic;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    interface IHistoricRepository
    {
        Historic GetHistoricById(int Event_Id);
        IEnumerable<Historic> GetHistoricPerDay(DateTime day);
        IEnumerable<HistoricStop> GetStops();
        IEnumerable<Historic> GetHistoricEvents();

    }
}
