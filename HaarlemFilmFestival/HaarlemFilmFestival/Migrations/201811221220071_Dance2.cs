namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dance2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dances", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dances", "EventId");
        }
    }
}
