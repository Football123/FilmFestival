namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .ForeignKey("dbo.Events", t => t.Dance_Id)
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
                    EindTime = c.DateTime(nullable: false),
                    Price = c.Double(nullable: false),
                    Discount = c.Double(),
                    Capacity = c.Int(),
                    Description = c.String(),
                    LocationId = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true);
                
            
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
                        OrderId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        RecordAmount = c.Int(nullable: false),
                        TicketType = c.String(),
                        RecordDescription = c.String(),
                    })
                .PrimaryKey(t => new { t.OrderId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(),
                        OrderTime = c.DateTime(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Code = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.HistoricStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StopDescription = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoricStops", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Themes", "Dance_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.OrderRecords", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Events", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.OrderRecords", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Events", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.ThemeArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ThemeArtists", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_Id" });
            DropIndex("dbo.ThemeArtists", new[] { "Artist_Id" });
            DropIndex("dbo.ThemeArtists", new[] { "Theme_Id" });
            DropIndex("dbo.HistoricStops", new[] { "LocationId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRecords", new[] { "EventId" });
            DropIndex("dbo.OrderRecords", new[] { "OrderId" });
            DropIndex("dbo.Events", new[] { "Restaurant_Id" });
            DropIndex("dbo.Events", new[] { "ArtistId" });
            DropIndex("dbo.Events", new[] { "ThemeId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.Themes", new[] { "Dance_Id" });
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.ThemeArtists");
            DropTable("dbo.HistoricStops");
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
