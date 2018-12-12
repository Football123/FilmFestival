using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Repositories
{
    interface IEventRepository
    {
        IEnumerable<Location> GetLocations();
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Event> GetAllEvents();
        Event GetEvent(int eventId);
        
    }
}