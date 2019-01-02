using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;

namespace HaarlemFilmFestival.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private HaarlemFilmFestivalContext database = HaarlemFilmFestivalContext.getInstance(); 
        private IEventRepository eventrepository = new EventRepository();

        public IEnumerable<Historic> GetHistoricPerDay(DateTime day)
        {
            IEnumerable<Historic> events = database.Historics.Where(a => DbFunctions.TruncateTime(a.StartTime) == day.Date);
            return events;
        }

        public IEnumerable<Historic> GetHistoricEvents()
        {
            IEnumerable<Historic> historics = database.Historics;
            return historics;
        }
        
        public IEnumerable<TimeSpan> GetStartTimes()
        {
            IEnumerable <TimeSpan> starttimes = database.Historics.Select(i => i.StartTime.TimeOfDay).Distinct();
            return starttimes;
        }

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            IEnumerable<OrderRecord> ordered = new List<OrderRecord>();
            ordered = database.OrderRecords.ToList();
            foreach (OrderRecord order in ordered)
            {
                Console.WriteLine(order.Event.Id);
            }
            return ordered;
        }

        public IEnumerable<HistoricStop> GetStops()
        {
            IEnumerable<HistoricStop> stops = database.HistoricStops;
            return stops;
        }
    }
}