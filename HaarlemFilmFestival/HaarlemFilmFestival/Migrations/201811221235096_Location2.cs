namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "EventId");
        }
    }
}
