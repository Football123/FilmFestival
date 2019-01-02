using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class HaarlemFilmFestivalContext : DbContext
    {
        private static HaarlemFilmFestivalContext uniqueInstance;

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public HaarlemFilmFestivalContext() : base("name=HaarlemFilmFestivalContext")
        {
            Database.SetInitializer<HaarlemFilmFestivalContext>(null);
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public static HaarlemFilmFestivalContext getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new HaarlemFilmFestivalContext();
            }
            return uniqueInstance;
        }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Historic> Historics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HistoricStop> HistoricStops { get; set; }
        public DbSet<OrderRecord> OrderRecords { get; set; }
        public DbSet<Jazz> Jazzs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Dance> Dances { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasMany(e => e.OrderRecords)
                 .WithRequired(eb => eb.Event)
                 .HasForeignKey(eb => eb.Event_Id);
            modelBuilder.Entity<Order>().HasMany(b => b.OrderRecords)
                .WithRequired(eb => eb.Order)
                .HasForeignKey(eb => eb.Order_Id);
        }
    }
}
