namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jazzupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jazzs", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jazzs", "EventId");
        }
    }
}
