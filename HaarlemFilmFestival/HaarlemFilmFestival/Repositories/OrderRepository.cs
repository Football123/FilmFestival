using System.Linq;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    public class OrderRepository
    {
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();

        public void AddNewOrder(Order order)
        {
            db.Orders.Add(order);
            //db.SaveChanges(); //tijdelijk 
            foreach (OrderRecord record in order.OrderRecords)
            {
                db.OrderRecords.Add(record);
                var item = db.Events.Find(record.Event_Id);
                db.Events.Where(i => i.Id == record.Event_Id).FirstOrDefault().Capacity = item.Capacity.Value - record.RecordAmount;
            }
            db.SaveChanges();
        }
    }
}