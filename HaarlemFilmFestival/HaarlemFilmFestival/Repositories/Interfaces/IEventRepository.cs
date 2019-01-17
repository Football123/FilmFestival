using HaarlemFilmFestival.Models;
using System.Collections.Generic;

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