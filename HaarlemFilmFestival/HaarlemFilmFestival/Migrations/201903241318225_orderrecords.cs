namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderrecords : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RestaurantCuisines", newName: "RestaurantCuisine1");
            CreateTable(
                "dbo.RestaurantCuisines",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Cuisine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Cuisine_Id });
            
            AddColumn("dbo.OrderRecords", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRecords", "TicketType", c => c.Int(nullable: false));
            DropColumn("dbo.Dances", "Theme_Id1");
            DropColumn("dbo.Dances", "Artist_Id1");
            DropColumn("dbo.Foods", "Restaurant_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Restaurant_Id1", c => c.String());
            AddColumn("dbo.Dances", "Artist_Id1", c => c.Int(nullable: false));
            AddColumn("dbo.Dances", "Theme_Id1", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRecords", "TicketType", c => c.String());
            DropColumn("dbo.OrderRecords", "Id");
            DropTable("dbo.RestaurantCuisines");
            RenameTable(name: "dbo.RestaurantCuisine1", newName: "RestaurantCuisines");
        }
    }
}
