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

        public IEnumerable<Event> GetHistoricEvents()
        {
            List<Event> historicEvents = new List<Event>();
            IEnumerable<Historic> historics = GetHistorics();
            foreach (Historic historic in historics)
            {
                Event historicEvent = database.Events.Where(he => he.Id == historic.Id).Include("Location").FirstOrDefault();
                historicEvents.Add(historicEvent);
            }
            return historicEvents;
        }

        public IEnumerable<Historic> GetHistorics()
        {
            IEnumerable<Historic> historics = database.Historics;
            return historics;
        }

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricStop> GetStops()
        {
            IEnumerable<HistoricStop> stops = database.HistoricStops;
            return stops;
        }
    }
}