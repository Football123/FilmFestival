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
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Location> Locations { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Orderregel> Orderregels { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Klant> Customers { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.Stops> Stops { get; set; }
        public System.Data.Entity.DbSet<HaarlemFilmFestival.Models.KoppelOrder> Koppelorders { get; set; }
    }
}
