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

        public IEnumerable<Historic> GetHistoricEvents()
        {
            IEnumerable<Historic> historics = database.Historics;
            return historics;
        }
        
        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            IEnumerable<OrderRecord> ordered = database.OrderRecords.ToList();
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