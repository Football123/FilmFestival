using System;
using System.Collections.Generic;
using System.Linq;
using HaarlemFilmFestival.Models;
using System.Data.Entity;

namespace HaarlemFilmFestival.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private HaarlemFilmFestivalContext database = HaarlemFilmFestivalContext.getInstance();
        private IEventRepository eventrepository = new EventRepository();

        public IEnumerable<Historic> GetHistoricEvents()
        {
            IEnumerable<Historic> historics = database.Historics.OrderBy(i => i.StartTime);
            return historics;
        }

        public Historic GetHistoricById(int Event_Id)
        {
            Historic item = database.Historics.Where(a => a.Id == Event_Id).SingleOrDefault();
            return item;
        }

        public IEnumerable<Historic> GetHistoricPerDay(DateTime day)
        {
            IEnumerable<Historic> events = database.Historics.Where(a => DbFunctions.TruncateTime(a.StartTime) == day.Date);
            return events;
        }
       
        public IEnumerable<HistoricStop> GetStops()
        {
            IEnumerable<HistoricStop> stops = database.HistoricStops;
            return stops;
        }
    }
}