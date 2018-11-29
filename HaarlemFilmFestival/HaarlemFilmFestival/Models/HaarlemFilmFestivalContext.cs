using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class HaarlemFilmFestivalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HaarlemFilmFestivalContext() : base("name=HaarlemFilmFestivalContext")
        {
        }

        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Jazz> Jazzs { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Food> Foods { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Dance> Dances { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.OrderRecord> OrderRecords { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.HistoricStop> HistoricStops { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Artist> Artists { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Cuisine> Cuisines { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Historic> Historics { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Location> Locations { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Restaurant> Restaurants { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasMany(e => e.OrderRecords)
                 .WithRequired(eb => eb.Event)
                 .HasForeignKey(eb => eb.EventId);
            modelBuilder.Entity<Order>().HasMany(b => b.OrderRecords)
                .WithRequired(eb => eb.Order)
                .HasForeignKey(eb => eb.OrderId);
        }
    }
}
