namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jazz1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jazzs", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jazzs", "EventId", c => c.Int(nullable: false));
        }
    }
}
