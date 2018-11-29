namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostFinal : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Dances", newName: "Events");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Orders");
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionDescription = c.String(),
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
                "dbo.SessionArtists",
                c => new
                    {
                        Session_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_Id, t.Artist_Id })
                .ForeignKey("dbo.Sessions", t => t.Session_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.Session_Id)
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
            
            AddColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EindTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "Discount", c => c.Double());
            AddColumn("dbo.Events", "Capacity", c => c.Int());
            AddColumn("dbo.Events", "Description", c => c.String());
            AddColumn("dbo.Events", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "SessionId", c => c.Int());
            AddColumn("dbo.Events", "ArtistId", c => c.Int());
            AddColumn("dbo.Events", "RestaurantId", c => c.String());
            AddColumn("dbo.Events", "Languages", c => c.Int());
            AddColumn("dbo.Events", "Band", c => c.String());
            AddColumn("dbo.Events", "JazzDescription", c => c.String());
            AddColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Events", "Restaurant_Id", c => c.Int());
            AddColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Locations", "Name", c => c.String());
            AddColumn("dbo.Locations", "Address", c => c.String());
            AddColumn("dbo.Locations", "ZipCode", c => c.String());
            AddColumn("dbo.Locations", "TelephoneNumber", c => c.Int());
            AddColumn("dbo.Locations", "Capacity", c => c.Int());
            AddColumn("dbo.Locations", "LocationDescription", c => c.String());
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
            AddColumn("dbo.Orders", "OrderTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Paid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.Events", "LocationId");
            CreateIndex("dbo.Events", "SessionId");
            CreateIndex("dbo.Events", "ArtistId");
            CreateIndex("dbo.Events", "Restaurant_Id");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Events", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "SessionId", "dbo.Sessions", "Id", cascadeDelete: true);
            DropColumn("dbo.Events", "DanceId");
            DropColumn("dbo.Events", "Artist");
            DropColumn("dbo.Events", "Session");
            DropColumn("dbo.Events", "EventId");
            DropColumn("dbo.Locations", "LocatieId");
            DropColumn("dbo.Locations", "Naam");
            DropColumn("dbo.Locations", "Adres");
            DropColumn("dbo.Locations", "Postcode");
            DropColumn("dbo.Locations", "Telefoonnummer");
            DropColumn("dbo.Locations", "Capaciteit");
            DropColumn("dbo.Locations", "Omschrijving");
            DropColumn("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "Betaalmethode");
            DropColumn("dbo.Orders", "Ordertijd");
            DropColumn("dbo.Orders", "Betaald");
            DropColumn("dbo.Orders", "KlantId");
            DropTable("dbo.Klants");
            DropTable("dbo.Events");
            DropTable("dbo.Foods");
            DropTable("dbo.KoppelOrders");
            DropTable("dbo.Orderregels");
            DropTable("dbo.Stops");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        StopsId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Omschrijving = c.String(),
                    })
                .PrimaryKey(t => t.StopsId);
            
            CreateTable(
                "dbo.Orderregels",
                c => new
                    {
                        OrderregelId = c.Int(nullable: false, identity: true),
                        Regelaantal = c.Int(nullable: false),
                        Tickettype = c.String(),
                        Opmerkingen = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderregelId);
            
            CreateTable(
                "dbo.KoppelOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderregelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Restaurant = c.String(),
                        Prijs_Adult = c.Int(nullable: false),
                        Prijs_Child = c.Int(nullable: false),
                        Type = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Begintijd = c.DateTime(nullable: false),
                        Eindtijd = c.DateTime(nullable: false),
                        Prijs = c.Int(nullable: false),
                        Korting = c.Int(nullable: false),
                        Capaciteit = c.Int(nullable: false),
                        Omschrijving = c.String(),
                        LocatieId = c.Int(nullable: false),
                        JazzId = c.Int(),
                        Band = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Klants",
                c => new
                    {
                        KlantId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Achternaam = c.String(),
                        Geboortedatum = c.DateTime(nullable: false),
                        Emailadres = c.String(),
                    })
                .PrimaryKey(t => t.KlantId);
            
            AddColumn("dbo.Orders", "KlantId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Betaald", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Ordertijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Betaalmethode", c => c.String());
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Locations", "Omschrijving", c => c.String());
            AddColumn("dbo.Locations", "Capaciteit", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Telefoonnummer", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Postcode", c => c.String());
            AddColumn("dbo.Locations", "Adres", c => c.String());
            AddColumn("dbo.Locations", "Naam", c => c.String());
            AddColumn("dbo.Locations", "LocatieId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Session", c => c.String());
            AddColumn("dbo.Events", "Artist", c => c.String());
            AddColumn("dbo.Events", "DanceId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.HistoricStops", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Sessions", "Dance_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.OrderRecords", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Events", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.OrderRecords", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Events", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.SessionArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.SessionArtists", "Session_Id", "dbo.Sessions");
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_Id" });
            DropIndex("dbo.SessionArtists", new[] { "Artist_Id" });
            DropIndex("dbo.SessionArtists", new[] { "Session_Id" });
            DropIndex("dbo.HistoricStops", new[] { "LocationId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRecords", new[] { "EventId" });
            DropIndex("dbo.OrderRecords", new[] { "OrderId" });
            DropIndex("dbo.Events", new[] { "Restaurant_Id" });
            DropIndex("dbo.Events", new[] { "ArtistId" });
            DropIndex("dbo.Events", new[] { "SessionId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.Sessions", new[] { "Dance_Id" });
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Events");
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "Paid");
            DropColumn("dbo.Orders", "OrderTime");
            DropColumn("dbo.Orders", "PaymentMethod");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Locations", "LocationDescription");
            DropColumn("dbo.Locations", "Capacity");
            DropColumn("dbo.Locations", "TelephoneNumber");
            DropColumn("dbo.Locations", "ZipCode");
            DropColumn("dbo.Locations", "Address");
            DropColumn("dbo.Locations", "Name");
            DropColumn("dbo.Locations", "Id");
            DropColumn("dbo.Events", "Restaurant_Id");
            DropColumn("dbo.Events", "Discriminator");
            DropColumn("dbo.Events", "JazzDescription");
            DropColumn("dbo.Events", "Band");
            DropColumn("dbo.Events", "Languages");
            DropColumn("dbo.Events", "RestaurantId");
            DropColumn("dbo.Events", "ArtistId");
            DropColumn("dbo.Events", "SessionId");
            DropColumn("dbo.Events", "LocationId");
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Capacity");
            DropColumn("dbo.Events", "Discount");
            DropColumn("dbo.Events", "Price");
            DropColumn("dbo.Events", "EindTime");
            DropColumn("dbo.Events", "StartTime");
            DropColumn("dbo.Events", "Id");
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.SessionArtists");
            DropTable("dbo.HistoricStops");
            DropTable("dbo.OrderRecords");
            DropTable("dbo.Customers");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
            DropTable("dbo.Sessions");
            DropTable("dbo.Artists");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Locations", "LocatieId");
            AddPrimaryKey("dbo.Events", "DanceId");
            RenameTable(name: "dbo.Events", newName: "Dances");
        }
    }
}
