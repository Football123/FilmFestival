namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArtistDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThemeDescription = c.String(),
                        Dance_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dances", t => t.Dance_Id)
                .Index(t => t.Dance_Id);
            
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuisineDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        Stars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(),
                        Capacity = c.Int(),
                        Description = c.String(),
                        Location_Id = c.Int(nullable: false),
                        Location_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id1)
                .Index(t => t.Location_Id1);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        TelephoneNumber = c.Int(),
                        Capacity = c.Int(),
                        LocationDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRecords",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                        RecordAmount = c.Int(nullable: false),
                        TicketType = c.String(),
                        RecordDescription = c.String(),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Event_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(),
                        OrderTime = c.DateTime(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Code = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Customer_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id1)
                .Index(t => t.Customer_Id1);
            
            CreateTable(
                "dbo.HistoriStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StopDescription = c.String(),
                        Location_Id = c.Int(nullable: false),
                        Location_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id1)
                .Index(t => t.Location_Id1);
            
            CreateTable(
                "dbo.ThemeArtists",
                c => new
                    {
                        Theme_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theme_Id, t.Artist_Id })
                .ForeignKey("dbo.Themes", t => t.Theme_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.Theme_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.RestaurantCuisines",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Cuisine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Cuisine_Id })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id, cascadeDelete: true)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Cuisine_Id);
            
            CreateTable(
                "dbo.Dances",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                        Theme_Id = c.Int(),
                        Theme_Id1 = c.Int(nullable: false),
                        Artist_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Themes", t => t.Theme_Id)
                .Index(t => t.Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Theme_Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                        Restaurant_Id1 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.Historics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Languages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Jazzs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Band_Id)
                .Index(t => t.Id)
                .Index(t => t.Band_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jazzs", "Band_Id", "dbo.Artists");
            DropForeignKey("dbo.Jazzs", "Id", "dbo.Events");
            DropForeignKey("dbo.Historics", "Id", "dbo.Events");
            DropForeignKey("dbo.Foods", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Foods", "Id", "dbo.Events");
            DropForeignKey("dbo.Dances", "Theme_Id", "dbo.Themes");
            DropForeignKey("dbo.Dances", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Dances", "Id", "dbo.Events");
            DropForeignKey("dbo.HistoriStops", "Location_Id1", "dbo.Locations");
            DropForeignKey("dbo.Themes", "Dance_Id", "dbo.Dances");
            DropForeignKey("dbo.OrderRecords", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id1", "dbo.Customers");
            DropForeignKey("dbo.OrderRecords", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Location_Id1", "dbo.Locations");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.ThemeArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ThemeArtists", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.Jazzs", new[] { "Band_Id" });
            DropIndex("dbo.Jazzs", new[] { "Id" });
            DropIndex("dbo.Historics", new[] { "Id" });
            DropIndex("dbo.Foods", new[] { "Restaurant_Id" });
            DropIndex("dbo.Foods", new[] { "Id" });
            DropIndex("dbo.Dances", new[] { "Theme_Id" });
            DropIndex("dbo.Dances", new[] { "Artist_Id" });
            DropIndex("dbo.Dances", new[] { "Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_Id" });
            DropIndex("dbo.ThemeArtists", new[] { "Artist_Id" });
            DropIndex("dbo.ThemeArtists", new[] { "Theme_Id" });
            DropIndex("dbo.HistoriStops", new[] { "Location_Id1" });
            DropIndex("dbo.Orders", new[] { "Customer_Id1" });
            DropIndex("dbo.OrderRecords", new[] { "Event_Id" });
            DropIndex("dbo.OrderRecords", new[] { "Order_Id" });
            DropIndex("dbo.Events", new[] { "Location_Id1" });
            DropIndex("dbo.Themes", new[] { "Dance_Id" });
            DropTable("dbo.Jazzs");
            DropTable("dbo.Historics");
            DropTable("dbo.Foods");
            DropTable("dbo.Dances");
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.ThemeArtists");
            DropTable("dbo.HistoriStops");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRecords");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
            DropTable("dbo.Themes");
            DropTable("dbo.Artists");
        }
    }
}
