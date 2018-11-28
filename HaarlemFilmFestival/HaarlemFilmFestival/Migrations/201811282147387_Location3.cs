namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Omschrijving", c => c.String());
            DropColumn("dbo.Locations", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "EventId", c => c.Int(nullable: false));
            DropColumn("dbo.Locations", "Omschrijving");
        }
    }
}
